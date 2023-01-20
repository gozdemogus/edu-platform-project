using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract.AbstractUOW;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;



        public AccountController(UserManager<AppUser> userManager, IAccountService accountService)
        {

            _userManager = userManager;
            _accountService = accountService;
        }


        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
            var aaaa = User.Identity.IsAuthenticated;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var credit = _accountService.GetByAppUserId(user.Id).Balance;
            ViewBag.credit = credit;

            return View(user);
        }


        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var account = _accountService.GetByAppUserId(user.Id);
            _accountService.TDelete(account);
            var result = await _userManager.DeleteAsync(user);

            foreach (var key in HttpContext.Request.Cookies.Keys)
            {
                HttpContext.Response.Cookies.Append(key, "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            }


            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Settings", "User");
            }
        }



        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(InAccountResetPasswordViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (model.NewPassword == model.ConfirmNewPassword)
            {
                var updateUser = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (updateUser.Succeeded)
                {
                    // Get the current user's ID
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    // Delete the user's cookies
                    await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

                    // Redirect the user to the home page
                    return RedirectToAction("Index", "Login");

                }
            }
            else
            {
                ModelState.AddModelError("", "An error occured.");
            }
            return RedirectToAction("User", "Settings");
        }


        [HttpGet]
        public async Task<IActionResult> UserEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();

            userUpdateViewModel.Name = values.Name;
            userUpdateViewModel.Surname = values.Surname;

            userUpdateViewModel.UserName = values.UserName;
            userUpdateViewModel.ImageUrl = values.Image;

            userUpdateViewModel.Email = values.Email;
            userUpdateViewModel.PhoneNumber = values.PhoneNumber;

            userUpdateViewModel.Speciality = values.Speciality;
            userUpdateViewModel.Website = values.Website;
            userUpdateViewModel.Department = values.Department;
            userUpdateViewModel.About = values.About;
            userUpdateViewModel.University = values.University;
            userUpdateViewModel.City = values.City;


            return View(userUpdateViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UserEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);


            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                values.Image = imageName;
                //imageName;
            }

            values.Name = model.Name;
            values.Surname = model.Surname;
            values.UserName = model.UserName;
            values.Email = model.Email;
            values.PhoneNumber = model.PhoneNumber;
            values.Department = model.Department;
            values.About = model.About;
            values.City = model.City;
            values.University = model.University;
            values.Website = model.Website;
            values.Speciality = model.Speciality;


            var saved = await _userManager.UpdateAsync(values);
            if (saved.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                ModelState.AddModelError("", "An error occured.");
                return View();
            }
        }

    }
}

