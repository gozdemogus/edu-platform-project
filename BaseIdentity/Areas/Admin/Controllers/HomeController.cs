using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


    }
}

