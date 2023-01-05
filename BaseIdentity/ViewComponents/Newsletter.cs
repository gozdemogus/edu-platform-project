using System;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Newsletter:ViewComponent
	{
		public Newsletter()
		{
		}

        public IViewComponentResult Invoke()
        {
            // var values = _categoryManager.TGetList();
            return View();
        }
    }
}

