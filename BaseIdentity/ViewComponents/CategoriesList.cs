using System;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class CategoriesList:ViewComponent
	{

        private readonly ICategoryService _categoryService;

        public CategoriesList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}

