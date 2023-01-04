using System;
namespace BaseIdentity.EntityLayer.Concrete
{
	public class AppUserCourse
	{
		public AppUserCourse()
		{
		}

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

