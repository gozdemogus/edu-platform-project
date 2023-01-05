using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface ICourseDal : IGenericDal<Course>
    {

        List<Course> GetCourseByLecturer(int LecturerId);
        Course GetCourseById(int id);
        public List<Course> GetCourseByCategory(int categoryId);
    }
}

