using System;
using System.Linq;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class CommentsByCourse:ViewComponent
	{
        private readonly ICommentService _CommentService;

        public CommentsByCourse(ICommentService CommentService)
        {
            _CommentService = CommentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _CommentService.FindByCourse(id).OrderByDescending(x=>x.dateTime).ToList();
            ViewBag.Count = values.Count;
            return View(values);
        }
    }
}

