using System;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class TopTechnologies:ViewComponent
	{

        private readonly ICategoryService categoryService;

        public TopTechnologies(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {

           var courses = categoryService.TGetList().ToList().Take(3).ToList();
            return View(courses);
        }
    }
}

