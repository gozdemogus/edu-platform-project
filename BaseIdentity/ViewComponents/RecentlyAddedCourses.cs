using System;
using System.Collections.Generic;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class RecentlyAddedCourses:ViewComponent
	{
        private readonly ICourseService _CourseService;

        public RecentlyAddedCourses(ICourseService CourseService)
        {
            _CourseService = CourseService;
        }
        public IViewComponentResult Invoke()
        {
            List<Course> courses = _CourseService.GetListWithDetail();

           
            var orderedCourses = courses.OrderBy(x => x.DateAdded).Take(3).ToList();
            return View(orderedCourses);
        }
    }
}

