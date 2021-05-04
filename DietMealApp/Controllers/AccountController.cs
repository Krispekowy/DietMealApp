using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using DietMealApp.Core.ViewModels.Identity;
using DietMealApp.DataAccessLayer;
using DietMealApp.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class AccountController : _ParentController
    {
        private readonly IConfiguration _configuration;
        private readonly AppUsersDbContext _appUsersDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AppUserDTO> _logger;

        public AccountController(
            IConfiguration configuration,
            AppUsersDbContext appUsersDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AppUserDTO> logger) 
            : base(configuration)
        {
            _configuration = configuration;
            _appUsersDbContext = appUsersDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl = null)
        {
            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserDTO appUser, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                    PhoneNumber = appUser.PhoneNumber,
                    PhoneNumberConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, appUser.Password);
                if (result.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(user.Email);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(appUser.Email, "Potwierdź adres e-mail",
                    //    $"Potwierdź swój adres e-mail klikając <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>tutaj</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = appUser.Email, returnUrl = returnUrl });
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
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var model = new LoginViewModel();
            string errorMessage = "";
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            model.ReturnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var hasErrorAlready = false;
            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Użytkownik zalogowany.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Konto użytkownika zablokowane.");
                    return RedirectToPage("./Lockout");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Proszę zweryfikować adres e-mail.");
                    hasErrorAlready = true;
                    return LocalRedirect(returnUrl);
                }
                if (hasErrorAlready == false)
                {
                    ModelState.AddModelError(string.Empty, "Logowanie nie powiodło się.");
                    return LocalRedirect(returnUrl);
                }
            }

            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
