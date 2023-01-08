using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly ICartService _cartService;
        private readonly ICartCourseService _cartCourseService;



        public CartController(UserManager<AppUser> userManager, ICourseService courseService, ICartService cartService, ICartCourseService cartCourseService)
        {

            _userManager = userManager;
            _courseService = courseService;
            _cartService = cartService;
            _cartCourseService = cartCourseService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var course = _courseService.FindForCart(user.Id);

            return View(course);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            _cartService.RemoveFromCart(id, user.Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var cart = _cartService.GetByOwner(user.Id);
          
          //kullanıcıya atanmıs sepet yoksa önce olustur
            if (cart == null)
            {
                Cart cartNew = new Cart();
                cartNew.AppUserId = user.Id;
                _cartService.TInsert(cartNew);
            }

            var cartAssured = _cartService.GetByOwner(user.Id);

            //sepetin id'si ile cartcourse tablosuna gidip, peki bu idli bi course kaydı var mı diye bakacak
           var isInCart = _cartCourseService.FindById(cartAssured.Id, id);

            if (isInCart != null) //eklenmis hata verecek
            {
                return PartialView("_ErrorMessage", "The item is already in the cart.");
            }
            else //eklendi ok!
            {
                _cartCourseService.AddNewCourseToCart(cart.Id, id);

                return PartialView("_SuccessMessage", "The item has been added to the cart.");
            }

        }
    }

}