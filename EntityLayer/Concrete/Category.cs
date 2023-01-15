using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class Category
	{

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}

