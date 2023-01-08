using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class WishlistTotal:ViewComponent
	{

        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;


        public WishlistTotal(ICartService cartService, UserManager<AppUser> userManager, ICourseService courseService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _courseService = courseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var course = _courseService.FindForCart(user.Id);
            ViewBag.Count = course.Count;


            return View();
        }
    }
}

