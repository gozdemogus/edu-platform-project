using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface ICartCourseDal : IGenericDal<CartCourse>
    {

		public void AddNewCourseToCart(int cartId, int courseId);

	}
}

