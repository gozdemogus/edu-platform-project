using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.PresentationLayer.CQRS.Results.CourseResults
{
	public class GetCourseByIdQueryResult
	{
		public int CourseId { get; set; }
		public double Price { get; set; }
		public string Title { get; set; }
		public string Language { get; set; }
        public string? Description { get; set; }
        public string? ContentURL { get; set; }
        public string? CoverPhoto { get; set; }
        public string? Level { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? InstructorId { get; set; }
        public AppUser? Instructor { get; set; }
    }
}

