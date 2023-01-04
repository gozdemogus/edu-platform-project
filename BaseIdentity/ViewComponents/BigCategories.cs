using System;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
    public class BigCategories : ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public BigCategories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetList().Take(6).ToList();
            return View(values);
        }
    }
}

