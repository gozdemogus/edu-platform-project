using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFCartCourseDal : GenericRepository<CartCourse>, ICartCourseDal
    {
		public EFCartCourseDal()
		{
		}

        public void AddNewCourseToCart(int cartId, int courseId)
        {
            using (var context = new Context())
            {

                CartCourse cartCourse = new CartCourse();
                cartCourse.CourseId = courseId;
                cartCourse.CartId = cartId;

                context.CartCourses.Add(cartCourse);
                context.SaveChanges();
            }
        }
    }
}

