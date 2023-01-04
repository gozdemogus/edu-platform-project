using System;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
    public class Hero : ViewComponent
    {
        public Hero()
        {
        }

        public IViewComponentResult Invoke(string text)
        {
            ViewBag.text = text;
            return View();
        }
    }
}

