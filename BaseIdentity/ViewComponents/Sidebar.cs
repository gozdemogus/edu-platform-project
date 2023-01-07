using System;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Sidebar:ViewComponent
	{
		public Sidebar()
		{
		}

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

