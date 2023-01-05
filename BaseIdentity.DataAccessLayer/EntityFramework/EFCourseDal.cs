using System;
using System.Linq;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFCourseDal : GenericRepository<Course>, ICourseDal
    {
		public EFCourseDal()
		{
		}

        public Course GetCourseById(int id)
        {
            using (var context = new Context())
            {
                var values = context.Courses
                    .Include(c => c.Instructor)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                return values;
            }
        }

        public List<Course> GetCourseByLecturer(int LecturerId)
        {
            using (var context = new Context())
            {
                var values = context.Courses.Where(x => x.InstructorId == LecturerId).ToList();
                return values;
            }
        }


        public List<Course> GetCourseByCategory(int categoryId)
        {
            using (var context = new Context())
            {
                var values = context.Courses.Where(x => x.CategoryId == categoryId).Include(x=>x.Instructor).ToList();
                return values;
            }
        }


    }
}

