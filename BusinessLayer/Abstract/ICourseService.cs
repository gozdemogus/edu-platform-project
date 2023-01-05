﻿using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface ICourseService : IGenericService<Course>
    {

        List<Course> GetCourseByLecturer(int LecturerId);

        Course GetCourseById(int id);

        public List<Course> GetCourseByCategory(int categoryId);
    }
}

