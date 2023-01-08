using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFWishlistCourseDal : GenericRepository<Wishlist>, IWishlistCourseDal
    {
		public EFWishlistCourseDal()
		{
		}

        public void AddToWishlist(int courseId, int wishlistId)
        {
            using (var context = new Context())
            {
                WishlistCourse wishlistCourse = new WishlistCourse();
                wishlistCourse.WishlistId = wishlistId;
                wishlistCourse.CourseId = courseId;
                context.WishlistCourses.Add(wishlistCourse);
                context.SaveChanges();
            }
        }

        
        public List<WishlistCourse> CoursesByWishlist(int wishlistId)
        {
            using (var context = new Context())
            {
                return context.WishlistCourses.Include(x=>x.Course).Where(x => x.WishlistId == wishlistId).ToList();
            }
        }

        public void Delete(WishlistCourse t)
        {
            throw new NotImplementedException();
        }

        public void Insert(WishlistCourse t)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromWishlist(int courseId, int wishlistId)
        {
            using (var context = new Context())
            {
             
               var wishlist = context.WishlistCourses.Where(x => x.CourseId == courseId && x.WishlistId == wishlistId).FirstOrDefault();
                context.WishlistCourses.Remove(wishlist);
                context.SaveChanges();
            }
        }

        public void Update(WishlistCourse t)
        {
            throw new NotImplementedException();
        }

        WishlistCourse IGenericDal<WishlistCourse>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<WishlistCourse> IGenericDal<WishlistCourse>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}

