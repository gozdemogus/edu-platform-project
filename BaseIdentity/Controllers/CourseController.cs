using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Models;
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

        public CourseController(ICourseService CourseService, UserManager<AppUser> userManager)
        {
            _CourseService = CourseService;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _CourseService.GetListWithDetail();
            return View(values);
        }

        public IActionResult CourseByLecturer(int id)
        {
            var values = _CourseService.GetCourseByLecturer(id);
            var name = values.FirstOrDefault().Instructor.Name;
            var surname = values.FirstOrDefault().Instructor.Surname;

            ViewBag.Name = name;
            ViewBag.Surname = surname;

            return View(values);
        }

        public async Task<IActionResult> CourseById(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _CourseService.GetCourseById(id);
            var isEnrolled = values.Enrollments.Where(x => x.AppUserId == user.Id).ToList();

            if (isEnrolled.Count != 0)
            {
                ViewBag.Enrolled = true;
            }
            else
            {
                ViewBag.Enrolled = false;
            }

            return View(values);
        }

        public IActionResult ByCategory(int id)
        {
            var values = _CourseService.GetCourseByCategory(id).ToList();
            return View(values);
        }



        public IActionResult SearchCourse(string keyword)
        {
           var values = _CourseService.SearchCourse(keyword);
            ViewBag.keyword = keyword;
            return View(values);
        }
    }
}

