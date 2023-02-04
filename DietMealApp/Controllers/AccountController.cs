using DietMealApp.Application.Commons.Services;
using DietMealApp.Core.Abstract;
using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Extensions;
using DietMealApp.Core.ViewModels.Identity;
using DietMealApp.DataAccessLayer;
using DietMealApp.Service;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DietMealApp.WebClient.Controllers
{
    public class AccountController : _ParentController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AppUserDTO> _logger;
        private readonly IMailService _mailService;
        private readonly IDeviceDetector _deviceDetector;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AppUserDTO> logger,
            IMediator mediator,
            IMailService mailService,
            IDeviceDetector deviceDetector) 
            : base(mediator, deviceDetector)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mailService = mailService;
            _deviceDetector = deviceDetector;
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
                    
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = user.Id, code }, Request.Scheme, Request.Host.ToString());

                    code = code.Base64ForUrlEncode();
                    var mail = new MailRequest()
                    {
                        ToEmail = appUser.Email,
                        Subject = "Potwierdzenie rejestracji",
                        Body = $"Cześć {user.FirstName}! Cieszymy się, że zarejestrowałaś się w naszej aplikacji. Aby w pełni z niej korzystać kliknij ten link: <a href=\"{link}\">tutaj</a>."
                    };
                    await _mailService.SendEmailAsync(mail);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToAction("RegisterConfirmation", new { email = appUser.Email, returnUrl = returnUrl });
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
        public async Task<IActionResult> RegisterConfirmation(string email, string returnUrl = null)
        {
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            
            string errorMessage = "";
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = Url.Content("~/"),
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };
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
                    return View(model);
                }
                if (hasErrorAlready == false)
                {
                    ModelState.AddModelError(string.Empty, "Logowanie nie powiodło się.");
                    return View(model);
                }
            }

            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, authenticationProperties);
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

        [HttpGet]
        public async Task<IActionResult> VerifyEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            InitId();
            string returnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(_senderId);
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    ViewData["Success"] = "Twoje hasło zostało zmienione!";
                    return View();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
                    var mail = new MailRequest()
                    {
                        ToEmail = user.Email,
                        Subject = "Resetowanie hasła",
                        Body = $"Cześć {user.FirstName}! Zapomniałeś hasła? Nie ma problemu, kliknij w podany link aby zmienić swoje hasło: <a href=\"{passwordResetLink}\">tutaj</a>."
                    };
                    await _mailService.SendEmailAsync(mail);
                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if(token == null || email == null)
            {
                ModelState.AddModelError("", "Nieprawidłowy token resetowania hasła");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user!=null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Błąd zewnętrznego dostawcy logowania: {remoteError}");
                return View("Login", loginViewModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Błąd ładowania informacji podczas logowania zewnętrznego");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email == null)
                {
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new AppUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await _userManager.CreateAsync(user);
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
                return LocalRedirect(returnUrl);
            }
        }
    }
}
