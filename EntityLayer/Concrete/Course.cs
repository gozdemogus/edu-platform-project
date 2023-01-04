using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class Course
	{
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    
        public string? Level { get; set; }
        public string? Price { get; set; }
        public string? Language { get; set; }
        public string? Prerequisities { get; set; }
        public string? WhatYoullLearn { get; set; }
        public int? Rank { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int InstructorId { get; set; }
        public AppUser Instructor { get; set; }
     
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}

