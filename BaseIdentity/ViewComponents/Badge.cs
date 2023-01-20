using System;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Badge:ViewComponent
	{

        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;


        public Badge(ICartService cartService, UserManager<AppUser> userManager, ICourseService courseService)
		{
            _cartService = cartService;
            _userManager = userManager;
            _courseService = courseService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(User.Identity.Name != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var course = _courseService.FindForCart(user.Id);
                    if (course != null)
                    {
                        ViewBag.Count = course.Count;
                    }
                }
            }


            return View();
        }
    }
}

