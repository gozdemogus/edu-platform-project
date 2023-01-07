using System;
namespace BaseIdentity.EntityLayer.Concrete
{
	public class Cart
	{
		public Cart()
		{
		}

        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<CartCourse> CartCourses { get; set; }


    }
}

