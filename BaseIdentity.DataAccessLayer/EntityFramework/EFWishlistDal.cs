using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFWishlistDal : GenericRepository<Wishlist>, IWishlistDal
    {
		public EFWishlistDal()
		{
		}

        public Wishlist FindByUser(int userId)
        {
            using (var context = new Context())
            {
                return context.Wishlists.Include(x=>x.WishlistCourses).Include(x=>x.AppUser).Where(x => x.AppUserId == userId).FirstOrDefault();
            }
        }
    }
}

