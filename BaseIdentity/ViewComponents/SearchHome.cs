using System;
using System.Collections.Generic;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class SearchHome:ViewComponent
	{

        private readonly ICategoryService _categoryService;

        public SearchHome(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            SearchCourseHomeViewModel searchCourseHomeViewModel = new SearchCourseHomeViewModel();

            List<SelectListItem> categories = (from x in _categoryService.TGetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.CategoryName
                                                     }).ToList();
            categories.Insert(0, new SelectListItem { Text = "Category", Value = string.Empty });

            ViewBag.cat = categories;


            return View(searchCourseHomeViewModel);
        }
    }
}

