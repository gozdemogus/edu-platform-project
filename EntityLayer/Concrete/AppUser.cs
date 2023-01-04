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
        public string? Phone { get; set; }
		public bool IsLecturer { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Course> InstructedCourses { get; set; }

    }
}

