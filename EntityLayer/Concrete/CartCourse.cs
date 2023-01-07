using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class CartCourse
	{

        [Key]
        public int CartCourseId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

