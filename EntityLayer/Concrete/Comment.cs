using System;
namespace BaseIdentity.EntityLayer.Concrete
{
	public class Comment
	{
        public int Id { get; set; }
        public string Text { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime dateTime { get; set; }
    }
}

