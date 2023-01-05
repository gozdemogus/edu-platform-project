using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseService _CourseService;

        public CourseController(ICourseService CourseService)
        {
            _CourseService = CourseService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _CourseService.TGetList();
            return View(values);
        }

        public IActionResult CourseByLecturer(int id)
        {
            var values = _CourseService.GetCourseByLecturer(id);
            return View(values);
        }

        public IActionResult CourseById(int id)
        {
            var values = _CourseService.GetCourseById(id);
            return View(values);
        }

        public IActionResult ByCategory(int id)
        {
            var values = _CourseService.GetCourseByCategory(id).ToList();
            return View(values);
        }

    }
}

