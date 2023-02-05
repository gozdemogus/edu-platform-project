using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using DTOLayer.DTOs.ContactDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public CategoryController(ICategoryService categoryService, IMapper mapper, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _categoryService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {

            Category categoryEdited = _categoryService.TGetById(category.CategoryID);
            categoryEdited.CategoryName = category.CategoryName;
            categoryEdited.Description = category.Description;
            categoryEdited.Icon = category.Icon;
            _categoryService.TUpdate(categoryEdited);

            var url = Url.RouteUrl("areas", new { controller = "Category", action = "Index", area = "Admin" });
            return Redirect(url);
        }

        public IActionResult Delete(int id)
        {
            Category category = _categoryService.TGetById(id);
            _categoryService.TDelete(category);

            var url = Url.RouteUrl("areas", new { controller = "Category", action = "Index", area = "Admin" });
            return Redirect(url);
        }

    }
}

