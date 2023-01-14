using System;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.PresentationLayer.CQRS.Queries.CourseQueries;
using BaseIdentity.PresentationLayer.CQRS.Results.CourseResults;

namespace BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers
{
	public class GetCourseByIdQueryHandler
	{
		private readonly Context _context;

        public GetCourseByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetCourseByIdQueryResult Handle(GetCourseByIdQuery query)
        {
            var values = _context.Courses.Find(query.Id);
            return new GetCourseByIdQueryResult
            {
                CourseId = values.Id,
                Language = values.Language,
                Price = (double)values.Price,
                Title = values.Title
            };
        }
    }
}

