using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface ICartCourseService : IGenericService<CartCourse>
    {

        public void AddNewCourseToCart(int cartId, int courseId);
        public CartCourse FindById(int cartId, int courseId);


    }
}

