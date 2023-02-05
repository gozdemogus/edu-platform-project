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
            if (!string.IsNullOrEmpty(command.Title))
            {
                values.Title = command.Title;
            }
            if (!string.IsNullOrEmpty(command.Language))
            {
                values.Language = command.Language;
            }
            if (command.Price > 0)
            {
                values.Price = command.Price;
            }
            if (!string.IsNullOrEmpty(command.Level))
            {
                values.Level = command.Level;
            }
            if (!string.IsNullOrEmpty(command.ContentURL))
            {
                values.ContentURL = command.ContentURL;
            }
            if (!string.IsNullOrEmpty(command.CoverPhoto))
            {
                values.CoverPhoto = command.CoverPhoto;
            }
            if (!string.IsNullOrEmpty(command.Description))
            {
                values.Description = command.Description;
            }
            if (command.CategoryId > 0)
            {
                values.CategoryId = command.CategoryId;
            }
            if (command.InstructorId > 0)
            {
                values.InstructorId = command.InstructorId;
            }
            _context.SaveChanges();
        }
    }
}

