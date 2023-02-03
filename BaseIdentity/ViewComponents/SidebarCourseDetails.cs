using System;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class SidebarCourseDetails:ViewComponent
	{
		
        private readonly IEnrollmentDal _enrollmentDal;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly ICartService _cartService;


        public SidebarCourseDetails(IEnrollmentDal enrollmentDal, UserManager<AppUser> userManager, ICourseService courseService, ICartService cartService)
        {
            _enrollmentDal = enrollmentDal;
            _userManager = userManager;
            _courseService = courseService;

            _cartService = cartService;

        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var result = _enrollmentDal.GetEnrollmentByOwner(user.Id);
                var isEnrolled = result.Where(x => x.CourseId == id).ToList();

                if (isEnrolled.Count != 0)
                {
                    ViewBag.Enrolled = true;
                    ViewBag.EnrollDate = isEnrolled.FirstOrDefault().EnrollmentDate.ToShortDateString();
                }
            }

         
            else
            {
                ViewBag.Enrolled = false;
            }

         
            return View();
        }


    }
    
}

