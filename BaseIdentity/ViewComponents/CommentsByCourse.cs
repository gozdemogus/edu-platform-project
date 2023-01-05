using System;
using BaseIdentity.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class CommentsByCourse:ViewComponent
	{
		public CommentsByCourse()
		{
		}


        public IViewComponentResult Invoke()
        {
           // var values = _categoryManager.TGetList();
            return View();
        }
    }
}

