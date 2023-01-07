using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class CartCourseManager:ICartCourseService
	{
        private readonly ICartCourseDal _cartCourseDal;

        public CartCourseManager(ICartCourseDal cartCourseDal)
        {
            _cartCourseDal = cartCourseDal;
        }

        public void AddNewCourseToCart(int cartId, int courseId)
        {
            _cartCourseDal.AddNewCourseToCart(cartId, courseId);
        }

        public void TDelete(CartCourse t)
        {
            throw new NotImplementedException();
        }

        public CartCourse TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CartCourse> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(CartCourse t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(CartCourse t)
        {
            throw new NotImplementedException();
        }
    }
}

