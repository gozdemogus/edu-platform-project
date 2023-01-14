using System;
namespace BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands
{
	public class UpdateCourseCommand
	{
        public int CourseId { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }
}

