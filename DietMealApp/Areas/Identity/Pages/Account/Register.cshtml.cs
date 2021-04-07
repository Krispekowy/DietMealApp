using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using DietMealApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using DietMealApp.DataAccessLayer;
using DietMealApp.Core.Validators;

namespace DietMealApp.WebClient.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AppUsersDbContext _context;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AppUsersDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        //[Required(ErrorMessage = "Musisz przejść przez weryfikację reCaptcha ")]
        //[BindProperty(Name = "g-recaptcha-response")]
        [GoogleReCaptchaValidation]
        public string GoogleReCaptchaResponse { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Podaj swoje imię")]
            [StringLength(64, ErrorMessage = "Maksymalna długość imienia to 64 znaki")]
            [RegularExpression(@"^[a-zA-ZążźśęćńłóĄŻŹĘĆŃÓŁŚ\-]{1,}$", ErrorMessage = "Imie nie może zawierać cyfr lub znaków specjalnych")]
            [Display(Name = "Imię")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Podaj swoje nazwisko")]
            [StringLength(64, ErrorMessage = "Maksymalna długość imienia to 64 znaki")]
            [RegularExpression(@"^[a-zA-ZążźśęćńłóĄŻŹĘĆŃÓŁŚ\-]{1,}$", ErrorMessage = "Nazwisko nie może zawierać cyfr lub znaków specjalnych")]
            [Display(Name = "Nazwisko")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Wybierz swoją nazwę użytkownika")]
            [Display(Name = "Nazwa użytkownika")]
            [RegularExpression(@"^[a-zA-Z0-9]{1,}$", ErrorMessage = "Nazwa użytkownika nie może zawierać znaków specjalnych")]
            [StringLength(64, ErrorMessage = "Maksymalna długość nazwy użytkownika to 64 znaki")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Podaj swój adres e-mail")]
            [EmailAddress(ErrorMessage = "Ten adres e-mail jest niepoprawny")]
            //[RegularExpression("[^@ \t\r\n]+@[^@ \t\r\n]+.[^@ \t\r\n]+", ErrorMessage = "Ten adres e-mail jest niepoprawny")]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Podaj swój numer telefonu")]
            [PhoneNumberValidator]
            [Display(Name = "Numer telefonu")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Wprowadź swoje hasło")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&.,])[A-Za-z\d@$!%*?&.,ąęśćźżłóĄĘŚĆŻŹŁÓ]{8,100}$", ErrorMessage = "W trosce o zabezpieczenie Twoich danych i tożsamości, hasło powinno spełniać następujące wymagania: przynajmniej jeden znak specjalny, duża i mała litera, oraz przynajmniej jedna cyfra. Minimalna długość hasła to 8 znaków. Niedozwolone są nawiasy, apostrofy, slash, backslash, małpa, znaki indexów górnych np. daszek, gwiazdka")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Hasła nie są identyczne")]
            public string ConfirmPassword { get; set; }

            public bool AllowReceivingTradeInformations { get; set; }
            public bool AllowProccesingMarketingInformations { get; set; }
            public bool AllowNewsletter { get; set; }
            [Required]
            public bool AcceptedRegulations { get; set; }
            [Required]
            public bool ReadInformationClause { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser() {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.UserName,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    PhoneNumberConfirmed = true
                    };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(user.Email);
                    _logger.LogInformation("User created a new account with password.");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Potwierdź adres e-mail",
                        $"Potwierdź swój adres e-mail klikając <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>tutaj</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
