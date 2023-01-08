using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class WishlistCourse
	{
		public WishlistCourse()
		{
		}

        [Key]
        public int Id { get; set; }

        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public object ToList()
        {
            throw new NotImplementedException();
        }
    }
}

