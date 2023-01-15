using System;
namespace BaseIdentity.PresentationLayer.CQRS.Commands.CourseCommands
{
	//eklemek istenilen properties
	public class CreateCourseCommand
	{
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ContentURL { get; set; }
        public string? CoverPhoto { get; set; }
        public string? Level { get; set; }
        public double? Price { get; set; }
        public string? Language { get; set; }
        public int? CategoryId { get; set; }

    }
}

