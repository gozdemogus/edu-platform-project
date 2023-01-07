using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentDal _enrollmentDal;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly ICartService _cartService;


        public EnrollmentController(IEnrollmentDal enrollmentDal, UserManager<AppUser> userManager, ICourseService courseService, ICartService cartService)
        {
            _enrollmentDal = enrollmentDal;
            _userManager = userManager;
            _courseService = courseService;

            _cartService = cartService;

        }



        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _enrollmentDal.GetEnrollmentByOwner(user.Id);

            return View(values);

        }

        public async Task<IActionResult> Enroll()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var courses = _courseService.FindForCart(user.Id);

            foreach (var item in courses)
            {
                Enrollment enrollment = new Enrollment();
            
                enrollment.AppUserId = user.Id;
        
                enrollment.CourseId = item.Id;
                enrollment.EnrollmentDate = DateTime.Now;

                _enrollmentDal.Insert(enrollment);
               
            }

            foreach (var item in courses)
            {
                _cartService.RemoveFromCart(item.Id, user.Id);
            }
        

            return RedirectToAction("Index");

        }

    }
}

