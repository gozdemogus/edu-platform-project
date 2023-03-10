using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class CourseController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _CourseService;
        private readonly IEnrollmentService _enrollmentService;


        public CourseController(ICourseService CourseService, UserManager<AppUser> userManager, IEnrollmentService enrollmentService)
        {
            _CourseService = CourseService;
            _userManager = userManager;
            _enrollmentService = enrollmentService;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var values = _CourseService.GetListWithDetail();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var enrolledCourses = _enrollmentService.GetEnrollmentByOwner(user.Id);
            ViewBag.enrolled = enrolledCourses;
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult CourseByLecturer(int id)
        {
            var values = _CourseService.GetCourseByLecturer(id);
            var name = values.FirstOrDefault()?.Instructor.Name;
            var surname = values.FirstOrDefault()?.Instructor.Surname;

            ViewBag.Name = name;
            ViewBag.Surname = surname;

            return View(values);
        }

        [AllowAnonymous]
        public async Task<IActionResult> CourseById(int id)
        {
            var values = _CourseService.GetCourseById(id);


            if (User.Identity.IsAuthenticated != false)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var isEnrolled = values.Enrollments.Where(x => x.AppUserId == user.Id).ToList();

                if (isEnrolled.Count != 0)
                {
                    ViewBag.Enrolled = true;
                }

                return View(values);
            }

          
            else
            {
                ViewBag.Enrolled = false;
            }

            return View(values);
        }

        [AllowAnonymous]
        public IActionResult ByCategory(int id)
        {
            var values = _CourseService.GetCourseByCategory(id).ToList();
            return View(values);
        }


        [AllowAnonymous]
        public IActionResult SearchCourse(string keyword)
        {
           var values = _CourseService.SearchCourse(keyword);
            ViewBag.keyword = keyword;
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult SearchCourseHome(SearchCourseHomeViewModel searchCourseHomeViewModel)
        {
            var values = _CourseService.SearchCourseHome(searchCourseHomeViewModel.Language, searchCourseHomeViewModel.CategoryName);
            ViewBag.keyword = searchCourseHomeViewModel.Language + " " + searchCourseHomeViewModel.CategoryName;
            return View(values);
        }
    }
}

