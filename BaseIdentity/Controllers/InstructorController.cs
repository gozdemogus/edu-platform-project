using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class InstructorController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public InstructorController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
            var users = await _userManager.Users
           .Where(u => u.IsLecturer == true).Include(x=>x.InstructedCourses).ToListAsync();

            return View(users);
        }

    }
}

