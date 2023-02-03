using System;
using System.Threading.Tasks;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class SendComment:ViewComponent
	{
        private readonly UserManager<AppUser> _userManager;

        public SendComment(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.user = user;

            Comment comment = new Comment();
            return View(comment);
        }
    }
}

