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
                    .Include(c=>c.Category)
                    .Include(c=>c.Enrollments)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                return values;
            }
        }

        public List<Course> GetCourseByLecturer(int LecturerId)
        {
            using (var context = new Context())
            {
                var values = context.Courses.Include(x=>x.Category).Where(x => x.InstructorId == LecturerId).Include(x=>x.Instructor).ToList();
                return values;
            }
        }


        public List<Course> GetCourseByCategory(int categoryId)
        {
            using (var context = new Context())
            {
                var values = context.Courses.Include(x=>x.Category).Where(x => x.CategoryId == categoryId).Include(x => x.Instructor).ToList();
                return values;
            }
        }



        public List<Course> FindForCart(int userId)
        {
            using (var context = new Context())
            {
                var courses = context.Carts
                  .Where(c => c.AppUserId == userId)
                  .SelectMany(c => c.CartCourses)
                  .Include(cc => cc.Course.Instructor)
                  .Select(cc => cc.Course)
                  .ToList();
                return courses;
            }
        }

        public List<Course> SearchCourse(string keyword)
        {
            using (var context = new Context())
            {

                var courses2 = context.Courses.ToList();

                var courses = context.Courses
                    .Include(x=>x.Category)
                    .Where(x => x.Title.Contains(keyword))
                     .Include(x => x.Instructor)
                     .ToList();

                return courses;
            }
        }

        public List<Course> GetListWithDetail()
        {
           using (var context = new Context())
            {
             return context.Courses.Include(x=>x.Instructor).Include(x=>x.Category).ToList();
            }
        }
    }
}
