using System;
using BaseIdentity.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BaseIdentity.PresentationLayer.Models
{
	public class CourseViewModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ContentURL { get; set; }
        public string? CoverPhoto { get; set; }
        public string? Level { get; set; }
        public string? Price { get; set; }
        public string? Language { get; set; }
        public string? Prerequisities { get; set; }
        public string? WhatYoullLearn { get; set; }
        public int? Rank { get; set; }



    }
}

