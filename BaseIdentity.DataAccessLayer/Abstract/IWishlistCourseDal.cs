using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface IWishlistCourseDal : IGenericDal<WishlistCourse>
    {
		public List<WishlistCourse> CoursesByWishlist(int wishlistId);

		public void AddToWishlist(int courseId, int wishlistId);
        public void RemoveFromWishlist(int courseId, int wishlistId);

    }
}

