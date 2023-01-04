﻿using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.BusinessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BaseIdentity.BusinessLayer.DIContainer
{
    public static class Extensions
    {

        public static void ContainerDependencies(this IServiceCollection services)
        {
          
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();


            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICourseDal, EFCourseDal>();
        }
    }
}
