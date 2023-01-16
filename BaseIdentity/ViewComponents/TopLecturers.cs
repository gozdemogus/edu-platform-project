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
            var usersInRole = await _userManager.GetUsersInRoleAsync("Lecturer");
            var users = await _userManager.Users
                .Include(x => x.InstructedCourses)
                .Where(u => usersInRole.Contains(u))
                .ToListAsync();


            return View(users);
        }
    }
}

