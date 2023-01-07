using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class PaymentController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly ICartService _cartService;
        private readonly EnrollmentController _enrollmentController;


        public PaymentController(UserManager<AppUser> userManager, ICourseService courseService, ICartService cartService, EnrollmentController enrollmentController)
        {

            _userManager = userManager;
            _courseService = courseService;
            _cartService = cartService;
            _enrollmentController = enrollmentController;
        }

       
    }
}

