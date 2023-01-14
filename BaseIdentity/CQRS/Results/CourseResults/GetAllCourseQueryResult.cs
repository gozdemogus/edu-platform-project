using System;
namespace BaseIdentity.PresentationLayer.CQRS.Results.CourseResults
{
	public class GetAllCourseQueryResult
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public double Price { get; set; }
		public string Language { get; set; }
	}
}

