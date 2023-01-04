using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _categoryService.TGetList().Take(4).ToList();
            var values2 = _categoryService.TGetList().Skip(4).Take(4).ToList();
            var values3 = _categoryService.TGetList().Skip(8).Take(4).ToList();

            ViewBag.c2 = values2;
            ViewBag.c3 = values3;

            return View(values);
        }
    }
}

