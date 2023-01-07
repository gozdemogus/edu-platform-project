using System;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Payment:ViewComponent
	{
		public Payment()
		{
		}

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

