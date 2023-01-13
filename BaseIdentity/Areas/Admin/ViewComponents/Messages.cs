using System;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.Areas.Admin.ViewComponents
{
	public class Messages:ViewComponent
	{
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

