using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface IWishlistCourseService : IGenericService<WishlistCourse>
    {
        public List<WishlistCourse> CoursesByWishlist(int wishlistId);
        public void AddToWishlist(int courseId, int wishlistId);
        public void RemoveFromWishlist(int courseId, int wishlistId);

    }
}

