using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands;
using BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers;
using BaseIdentity.PresentationLayer.CQRS.Queries.CourseQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CourseCQRSController : Controller
    {
        private readonly GetAllCourseQueryHandler _getAllCourseQueryHandler;
        private readonly GetCourseByIdQueryHandler _getCourseByIdQueryHandler;
        private readonly CreateCourseCommandHandler _createCourseCommandHandler;
        private readonly RemoveCourseCommandHandler _removeCourseCommandHandler;
        private readonly UpdateCourseCommandHandler _updateCourseCommandHandler;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;



        public CourseCQRSController(GetAllCourseQueryHandler getAllCourseQueryHandler, GetCourseByIdQueryHandler getCourseByIdQueryHandler, CreateCourseCommandHandler createCourseCommandHandler, RemoveCourseCommandHandler removeCourseCommandHandler, UpdateCourseCommandHandler updateCourseCommandHandler, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _getAllCourseQueryHandler = getAllCourseQueryHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
            _createCourseCommandHandler = createCourseCommandHandler;
            _removeCourseCommandHandler = removeCourseCommandHandler;
            _updateCourseCommandHandler = updateCourseCommandHandler;
            _categoryService = categoryService;
            _userManager = userManager;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _getAllCourseQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourse(int id)
        {
            ViewBag.Instructors = await _userManager.Users.Where(u => u.IsLecturer == true).ToListAsync();


            ViewBag.Categories = _categoryService.TGetList();
            var values = _getCourseByIdQueryHandler.Handle(new GetCourseByIdQuery(id));
            return View(values);
        }


        [HttpPost]
        public IActionResult GetCourse(UpdateCourseCommand command)
        {
            _updateCourseCommandHandler.Handle(command);
            var url = Url.RouteUrl("areas", new { controller = "CourseCQRS", action = "Index", area = "Admin" });
            return Redirect(url);
        }


        [HttpGet]
        public async Task<IActionResult> AddCourse()
        {
            ViewBag.Instructors = await _userManager.Users.Where(u => u.IsLecturer == true).ToListAsync();


            ViewBag.Categories = _categoryService.TGetList();
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(CreateCourseCommand command)
        {
            _createCourseCommandHandler.Handle(command);
            var url = Url.RouteUrl("areas", new { controller = "CourseCQRS", action = "Index", area = "Admin" });
            return Redirect(url);
        }

        public IActionResult Delete(int id)
        {
            _removeCourseCommandHandler.Handle(new RemoveCourseCommand(id));
            var url = Url.RouteUrl("areas", new { controller = "CourseCQRS", action = "Index", area = "Admin" });
            return Redirect(url);
        }
    }
}

