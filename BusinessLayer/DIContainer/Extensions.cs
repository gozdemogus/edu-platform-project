using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.BusinessLayer.Abstract.AbstractUOW;
using BaseIdentity.BusinessLayer.Concrete;
using BaseIdentity.BusinessLayer.Concrete.ConcreteUOW;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.EntityFramework;
using BaseIdentity.DataAccessLayer.UnitOfWork;
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

            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartDal, EFCartDal>();


            services.AddScoped<IEnrollmentService, EnrollmentManager>();
            services.AddScoped<IEnrollmentDal, EFEnrollmentDal>();


            services.AddScoped<ICartCourseService, CartCourseManager>();
            services.AddScoped<ICartCourseDal, EFCartCourseDal>();

            services.AddScoped<IWishlistCourseService, WishlistCourseManager>();
            services.AddScoped<IWishlistCourseDal, EFWishlistCourseDal>();

            services.AddScoped<IWishlistService, WishlistManager>();
            services.AddScoped<IWishlistDal, EFWishlistDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<ITodoListService, TodoListManager>();
            services.AddScoped<ITodoListDal, EFTodoListDal>();

            services.AddScoped<ITodoItemService, TodoItemManager>();
            services.AddScoped<ITodoItemDal, EFTodoItemDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EFAccountDal>();

            services.AddScoped<IUOWDal, UOWDal>();
        }
    }
}

