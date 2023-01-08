using System;
using Microsoft.AspNetCore.Identity;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class AppUser:IdentityUser<int>
	{
		public AppUser()
		{
		}

		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Image { get; set; }
        public string? MailCode { get; set; }
    
        public string? City { get; set; }
        public string? About { get; set; }
        public string? University { get; set; }
        public string? Department { get; set; }
        public bool IsLecturer { get; set; }
        public string? LastActivity { get; set; }
        public string? Rank { get; set; }
        public string? Speciality { get; set; }
        public string? Website { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Course> InstructedCourses { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }


        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public List<Comment> Comments { get; set; }


    }
}

