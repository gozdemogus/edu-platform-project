using System;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands;

namespace BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers
{
	public class UpdateCourseCommandHandler
	{
		private readonly Context _context;

        public UpdateCourseCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateCourseCommand command)
        {
            var values = _context.Courses.Find(command.CourseId);
            values.Title = command.Title;
            values.Language = command.Language;
            values.Price = command.Price;
            values.Level = command.Level;
            values.ContentURL = command.ContentURL;
            values.CoverPhoto = command.CoverPhoto;
            values.Description = command.Description;
            values.CategoryId = command.CategoryId;
            _context.SaveChanges();
        }
    }
}

