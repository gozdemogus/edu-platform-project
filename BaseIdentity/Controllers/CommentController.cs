using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;


        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }


        public async Task MakeAComment(string Text, string Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            Comment comment = new Comment();
            comment.Text = Text;
            comment.dateTime = DateTime.Now;
            comment.AppUserId = user.Id;
            comment.CourseId = Int32.Parse(Id);
            _commentService.TInsert(comment);
        }

    }
}

