using System;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.Areas.Admin.ViewComponents
{
	public class ToDoList:ViewComponent
	{

        private readonly UserManager<AppUser> _userManager;
        private readonly ITodoListService _todoListService;

        public ToDoList(ITodoListService todoListService, UserManager<AppUser> userManager)
        {
            _todoListService = todoListService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _todoListService.getTodoListByUser(user.Id);

            if (values.UserId == null)
            {
                ViewBag.nolist = true;
            }

            return View(values);
        }
    }
}

