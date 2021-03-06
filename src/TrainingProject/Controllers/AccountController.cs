﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext context)
        {
            _db = context;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                await Authenticate(model.Email);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    _db.ApplicationUsers.Add(new ApplicationUser { Email = model.Email, Password = model.Password });
                    await _db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
                    };
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction("Login", "Account");
        }

    }
}
