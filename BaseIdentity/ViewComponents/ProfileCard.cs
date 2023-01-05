using System;
using BaseIdentity.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class ProfileCard:ViewComponent
	{
		public ProfileCard()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

