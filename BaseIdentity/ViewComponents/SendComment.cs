using System;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class SendComment:ViewComponent
	{

        public IViewComponentResult Invoke()
        {
            // var values = _categoryManager.TGetList();
            return View();
        }
    }
}

