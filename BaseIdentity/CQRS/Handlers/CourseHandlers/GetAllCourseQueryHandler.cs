using System;
using System.Collections.Generic;
using System.Linq;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.PresentationLayer.CQRS.Results.CourseResults;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.PresentationLayer.CQRS.Handlers.CourseHandlers
{
	public class GetAllCourseQueryHandler
	{
		private readonly Context _context;

        public GetAllCourseQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllCourseQueryResult> Handle()
        {
            var values = _context.Courses.Select(x => new GetAllCourseQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Language = x.Language,
                Price= (double)x.Price
            }).AsNoTracking().ToList();

            return values;
        }
    }
}

