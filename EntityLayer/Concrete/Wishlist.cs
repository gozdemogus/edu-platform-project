using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class Wishlist
	{
		public Wishlist()
		{
		}
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<WishlistCourse> WishlistCourses { get; set; }

    }
}

