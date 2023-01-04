using System;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
    public class NewTutorials : ViewComponent
    {

        private readonly ICourseService _CourseService;

        public NewTutorials(ICourseService CourseService)
        {
            _CourseService = CourseService;
        }

        public IViewComponentResult Invoke()
        {
           var values = _CourseService.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}

