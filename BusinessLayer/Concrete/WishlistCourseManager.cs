using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class WishlistCourseManager:IWishlistCourseService
	{
        private readonly IWishlistCourseDal _wishlistCourseDal;

        public WishlistCourseManager(IWishlistCourseDal wishlistCourseDal)
        {
            _wishlistCourseDal = wishlistCourseDal;
        }

        public void AddToWishlist(int courseId, int wishlistId)
        {
            _wishlistCourseDal.AddToWishlist(courseId, wishlistId);
        }

        public List<WishlistCourse> CoursesByWishlist(int wishlistId)
        {
          return  _wishlistCourseDal.CoursesByWishlist(wishlistId);
        }

        public void RemoveFromWishlist(int courseId, int wishlistId)
        {
            _wishlistCourseDal.RemoveFromWishlist(courseId, wishlistId);
        }

        public void TDelete(WishlistCourse t)
        {
            throw new NotImplementedException();
        }

        public WishlistCourse TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<WishlistCourse> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(WishlistCourse t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WishlistCourse t)
        {
            throw new NotImplementedException();
        }
    }
}

