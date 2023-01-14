using System;
namespace BaseIdentity.PresentationLayer.CQRS.Results.CourseResults
{
	public class GetCourseByIdQueryResult
	{
		public int CourseId { get; set; }
		public double Price { get; set; }
		public string Title { get; set; }
		public string Language { get; set; }
	}
}

