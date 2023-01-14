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
        public string? ContentURL { get; set; }
        public string? Includes { get; set; }
        public string? CoverPhoto { get; set; }
        public string? Level { get; set; }
        public double? Price { get; set; }
        public string? Language { get; set; }
        public string? Prerequisities { get; set; }
        public string? WhatYoullLearn { get; set; }
        public string? Rank { get; set; }
        public string? SuitableFor { get; set; }
        public string? Tags { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public Category? Category { get; set; }

        public int? InstructorId { get; set; }
        public AppUser? Instructor { get; set; }
     
        public ICollection<Enrollment> Enrollments { get; set; }

        public List<CartCourse> CartCourses { get; set; }

        public List<WishlistCourse> WishlistCourses { get; set; }

        public List<Comment> Comments { get; set; }


    }
}

