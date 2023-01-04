using System;
using BaseIdentity.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
    public class TopCategories : ViewComponent
    {
        private readonly CategoryManager _categoryManager;

        public TopCategories(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public IViewComponentResult Invoke()
        {
            var values = _categoryManager.TGetList();
            return View(values);
        }
    }
}

