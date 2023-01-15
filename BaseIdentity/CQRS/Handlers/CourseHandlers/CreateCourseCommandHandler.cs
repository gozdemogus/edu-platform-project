using System;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands;

namespace BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers
{
	public class CreateCourseCommandHandler
	{
		private readonly Context _context;

        public CreateCourseCommandHandler(Context context)
        {
            _context = context;
        }
   

	public void Handle(CreateCourseCommand command)
	{
			_context.Courses.Add(new Course
			{
				Language = command.Language,
				Price = command.Price,
				Title = command.Title,
				Description = command.Description,
				ContentURL = command.ContentURL,
				CoverPhoto = command.CoverPhoto,
				Level = command.Level,
				CategoryId =command.CategoryId,
				InstructorId=command.InstructorId
			});

			_context.SaveChanges();
	}

    }

}

