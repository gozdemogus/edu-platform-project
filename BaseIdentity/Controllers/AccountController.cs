using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;


        public AccountController( UserManager<AppUser> userManager)
        {
    
            _userManager = userManager;
        }


        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
         var aaaa= User.Identity.IsAuthenticated;
         var user= await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}

