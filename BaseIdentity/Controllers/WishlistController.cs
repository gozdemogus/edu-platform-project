using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class WishlistController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWishlistService _wishlistService;
        private readonly IWishlistCourseService _wishlistCourseService;

        public WishlistController(UserManager<AppUser> userManager, IWishlistService wishlistService, IWishlistCourseService wishlistCourseService)
        {
            _userManager = userManager;
            _wishlistService = wishlistService;
            _wishlistCourseService = wishlistCourseService;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var wishlistByUser = _wishlistService.FindByUser(user.Id);
            var wishlistCourses = _wishlistCourseService.CoursesByWishlist(wishlistByUser.Id);
            var courses = wishlistCourses.Select(wc => wc.Course).ToList();
            return View(courses);
        }

        // TODO bu method refaktor edilecek!!
        public async Task<IActionResult> AddToWishlist(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userWishlist = _wishlistService.FindByUser(user.Id);

            //önce kullanıcının bi wishlist'i var mı bakacak, yoksa olusturacak
            if (userWishlist == null)
            {
                Wishlist wishlist = new Wishlist();
                wishlist.AppUserId = user.Id;
                _wishlistService.TInsert(wishlist);

                //olusturuldu, simdi listeye önceden eklenmis mi diye bakacak
                var isAlreadyAdded = userWishlist.WishlistCourses.Where(x => x.CourseId == id).ToList().Count;
                if (isAlreadyAdded != 0) //eklenmis hata verecek
                {
                    return PartialView("_ErrorMessage", "The item is already in the wishlist.");
                }
                else //eklendi ok!
                {
                    var wishlistByUser = _wishlistService.FindByUser(user.Id);
                    _wishlistCourseService.AddToWishlist(id, wishlistByUser.Id);

                    return PartialView("_SuccessMessage", "The item has been added to the wishlist.");
                }

            }
            else //wishlist var simdi listeye önceden eklenmis mi diye bakacak
            {
                var isAlreadyAdded = userWishlist.WishlistCourses.Where(x => x.CourseId == id).ToList().Count;
                if (isAlreadyAdded != 0) //eklenmis hata verecek
                {
                    return PartialView("_ErrorMessage", "The item is already in the wishlist.");
                }
                else //eklendi ok!
                {
                    var wishlistByUser = _wishlistService.FindByUser(user.Id);
                    _wishlistCourseService.AddToWishlist(id, wishlistByUser.Id);

                    return PartialView("_SuccessMessage", "The item has been added to the wishlist.");
                }
            }
        }

        public async Task<IActionResult> RemoveFromWishlist(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var userWishlist = _wishlistService.FindByUser(user.Id);


            var wishlistByUser = _wishlistService.FindByUser(user.Id);

            _wishlistCourseService.RemoveFromWishlist(id, wishlistByUser.Id);

            return RedirectToAction("Index");
        }


    }
}

