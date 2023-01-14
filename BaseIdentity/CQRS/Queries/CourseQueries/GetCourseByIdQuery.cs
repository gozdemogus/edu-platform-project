using System;
namespace BaseIdentity.PresentationLayer.CQRS.Queries.CourseQueries
{
	public class GetCourseByIdQuery
	{
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

	}
}

