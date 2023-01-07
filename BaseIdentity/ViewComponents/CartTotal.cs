using System;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class CartTotal:ViewComponent
	{
        private readonly UserManager<AppUser> _userManager;

        private readonly ICartService _cartService;

        public CartTotal(UserManager<AppUser> userManager, ICartService cartService)
        {

            _userManager = userManager;
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            using (var context = new Context())
            {
                var total = await context.Carts
                    .Where(c => c.AppUserId == user.Id)
                    .SelectMany(c => c.CartCourses)
                    .Select(cc => cc.Course.Price)
                    .SumAsync();

                ViewBag.Total = total;
            }
            return View();
        }
    }
}

