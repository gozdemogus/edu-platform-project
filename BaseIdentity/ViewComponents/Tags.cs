using System;
using BaseIdentity.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Tags:ViewComponent
	{
		public Tags()
		{
		}

        public IViewComponentResult Invoke()
        {
            //var values = _categoryManager.TGetList();
            //return View(values);
            return View();
        }
    }
}

