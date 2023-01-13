using System;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.Areas.Admin.ViewComponents
{
	public class AddTodoList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}

