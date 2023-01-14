using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands;
using BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers;
using BaseIdentity.PresentationLayer.CQRS.Queries.CourseQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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



        public CourseCQRSController(GetAllCourseQueryHandler getAllCourseQueryHandler, GetCourseByIdQueryHandler getCourseByIdQueryHandler, CreateCourseCommandHandler createCourseCommandHandler, RemoveCourseCommandHandler removeCourseCommandHandler, UpdateCourseCommandHandler updateCourseCommandHandler)
        {
            _getAllCourseQueryHandler = getAllCourseQueryHandler;
            _getCourseByIdQueryHandler = getCourseByIdQueryHandler;
            _createCourseCommandHandler = createCourseCommandHandler;
            _removeCourseCommandHandler = removeCourseCommandHandler;
            _updateCourseCommandHandler = updateCourseCommandHandler;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _getAllCourseQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetCourse(int id)
        {
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
        public IActionResult AddCourse()
        {
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

