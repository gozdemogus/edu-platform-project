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

        public void TDelete(Course t)
        {
            throw new NotImplementedException();
        }

        public Course TGetById(int id)
        {
            throw new NotImplementedException();
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

