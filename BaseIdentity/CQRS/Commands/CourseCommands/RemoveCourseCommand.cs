using System;
namespace BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands
{
	public class RemoveCourseCommand
	{
		public RemoveCourseCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}

