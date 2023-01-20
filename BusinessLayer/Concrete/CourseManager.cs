using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class CourseManager : ICourseService
    {

        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public List<Course> FindForCart(int userId)
        {
          return  _courseDal.FindForCart(userId);
        }

        public List<Course> GetCourseByCategory(int categoryId)
        {
           return _courseDal.GetCourseByCategory(categoryId);
        }

        public Course GetCourseById(int id)
        {
          return  _courseDal.GetCourseById(id);
        }

        public List<Course> GetCourseByLecturer(int LecturerId)
        {
          return  _courseDal.GetCourseByLecturer(LecturerId);
        }

        public List<Course> GetListWithDetail()
        {
            return _courseDal.GetListWithDetail();
        }

        public List<Course> SearchCourse(string keyword)
        {
            return _courseDal.SearchCourse(keyword);
        }

        public List<Course> SearchCourseHome(string language, string category)
        {
            return _courseDal.SearchCourseHome(language, category);
        }

        public void TDelete(Course t)
        {
            throw new NotImplementedException();
        }

        public Course TGetById(int id)
        {
          return  _courseDal.GetById(id);
        }

        public List<Course> TGetList()
        {
            return _courseDal.GetList();
        }

        public void TInsert(Course t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Course t)
        {
            throw new NotImplementedException();
        }
    }
}

