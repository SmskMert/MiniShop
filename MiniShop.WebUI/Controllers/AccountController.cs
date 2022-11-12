using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShop.Core;
using MiniShop.WebUI.Identity;
using MiniShop.WebUI.Models;

namespace MiniShop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            var user = new User()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Tebrikler!", "Kayıt işleminiz başarıyla tamamlanmıştır.", "success");

                return RedirectToAction("Login", "Account");
            }
            return View(registerModel);
        }

        public IActionResult Login(string returnUrl = null)
        {
           
                return View(new LoginModel()
                 { ReturnUrl = returnUrl }
                 );
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                 var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya şifre hatalı");
                return View(loginModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, true, false);
            if (result.Succeeded)
            {
                return Redirect(loginModel.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "şifre hatalı!");
            }
           
            return View(loginModel);
        }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Redirect("~/");
    }
    }

}