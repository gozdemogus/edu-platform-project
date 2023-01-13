using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.Areas.Admin.ViewComponents
{
	public class ToDoList:ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

