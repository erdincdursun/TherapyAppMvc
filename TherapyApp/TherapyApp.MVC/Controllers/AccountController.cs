using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using TherapyApp.Entity.Concrete;
using TherapyApp.MVC.Models;
using ThreapyApp.MVC.EmailServices.Abstract;

namespace TherapyApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotyfService _notify;
        private readonly IEmailSender _smtpEmailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, INotyfService notify, IEmailSender smtpEmailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notify = notify;
            _smtpEmailSender = smtpEmailSender;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        _notify.Success("Successfully logged in.");
                        return Redirect("/");
                    }
                }

                _notify.Error("Invalid username or password");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    #region Sending Confirmation Email
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    //var url = Url.Action("ConfirmEmail", "Account", new
                    //{
                    //    userId = user.Id,
                    //    token = code
                    //});
                    //var email = model.Email;
                    //var subject = "Therapy App Confirmation Mail";
                    //var body = $"<h1>Therapy Confirmation Process</h1>" +
                    //    $"<p>" +
                    //    $"Please confirm your subscription. <a href='http://localhost:5177{url}'>click here</a>." +
                    //    $"</p>";
                    //await _smtpEmailSender.SendEmailAsync(email, subject, body);
                    #endregion
                    await _userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (email == null)
            {
                ViewBag.EmailErrorMessage = "Please do not leave your e-mail address blank";
                return View();
            }
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ViewBag.EmailErrorMessage = "No such user found";
                return View();
            }
            #region Sending Password Reset Email

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            var subject = "Terapy App Password Reset";
            var body = $"<h1>Terapy App Password Rese</h1>" +
                $"<p>" +
                $"Please change your password. <a href='http://localhost:5177{url}'>click here</a>." +
                $"</p>";
            await _smtpEmailSender.SendEmailAsync(email, subject, body);
            #endregion
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult ResetPasword()
        {
            return View();
        }

        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                _notify.Error("Error");
                return Redirect("~/");
            }
            User user = await _userManager.FindByIdAsync(userId);
            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                UserId = userId,
                Token = token
            };
            return View(model);
        }

        [Authorize(Roles = "Admin, User")]

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    _notify.Warning("User is not found ");
                    return View();
                }
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    _notify.Success("The password has been successfully changed.");
                    return RedirectToAction("Login");
                }
            }
            _notify.Warning("Error");
            return View();
        }
    }
}
