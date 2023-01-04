﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash, false, true);
            var user = await _userManager.FindByNameAsync(appUser.UserName);
            var confirmed = user.EmailConfirmed;

            // if (result.Succeeded && appUser.EmailConfirmed == true)
            if (result.Succeeded && confirmed == true)
            {
                //  var url = Url.RouteUrl("areas", new { controller = "Employee", action = "Index", area = "Employee" });
                //  return Redirect(url);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }

    }
}

