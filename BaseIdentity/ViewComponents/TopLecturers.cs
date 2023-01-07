using System;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class TopLecturers:ViewComponent
	{
        private readonly UserManager<AppUser> _userManager;

        public TopLecturers(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userManager.Users
           .Where(u => u.IsLecturer == true).Include(x => x.InstructedCourses).ToListAsync();

            return View(users);
        }
    }
}

