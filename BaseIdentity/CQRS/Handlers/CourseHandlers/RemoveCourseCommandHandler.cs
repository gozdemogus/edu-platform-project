using System;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands;

namespace BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers
{
	public class RemoveCourseCommandHandler
	{
        private readonly Context _context;

        public RemoveCourseCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveCourseCommand command)
        {
            var values = _context.Courses.Find(command.Id);
            _context.Courses.Remove(values);
            _context.SaveChanges();
        }

    }
}

