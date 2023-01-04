using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.PresentationLayer.Models
{
    public class AppUserRegisterViewModel
    {
        public AppUserRegisterViewModel()
        {
        }
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mail required")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password required")]
        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }
    }
}

