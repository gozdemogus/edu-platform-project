using System;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class TopCategoriesHome:ViewComponent
	{
        private readonly ICategoryService _categoryService;

        public TopCategoriesHome(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.DetailedCategories().OrderByDescending(x=>x.CategoryName).Take(2).ToList();
            var values2 = _categoryService.DetailedCategories().OrderByDescending(x => x.CategoryName).Skip(2).Take(2).ToList();
            var values3 = _categoryService.DetailedCategories().OrderByDescending(x => x.CategoryName).Skip(4).Take(2).ToList();

            ViewBag.c2 = values2;
            ViewBag.c3 = values3;

            return View(values);
        }
    }
}

