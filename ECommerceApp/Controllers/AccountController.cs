using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Identity;
using ECommerceApp.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterData data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            await userService.Register(data, ModelState);

            if (!ModelState.IsValid)
            {
                return View(data);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginData data)
        {
            var user = await userService.Authenticate(data);
            if (user != null)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(nameof(LoginData.Password), "Email or Password was incorrect.");

            return View(data);
        }
    }
}