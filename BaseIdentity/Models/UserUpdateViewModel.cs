using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.PresentationLayer.Models
{
	public class UserUpdateViewModel
	{

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string About { get; set; }
        public string Website { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Speciality { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
      
    }
}

