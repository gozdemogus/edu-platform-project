using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Models;
using DTOLayer.DTOs.AppUserDTOs;
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
        private readonly ITodoListService _todoListService;
        private readonly IMapper _mapper;


        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITodoListService todoListService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _todoListService = todoListService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(p.username);
                var confirmed = user.EmailConfirmed;

                    // if (result.Succeeded && appUser.EmailConfirmed == true)
                    if (confirmed == true)
                    { 
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //ModelState.AddModelError("error", "E-Mail is not confirmed.");
                        return RedirectToAction("EmailConfirmed", "Register");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Password or username is wrong.");

                }
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

