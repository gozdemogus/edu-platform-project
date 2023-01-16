using System;
using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOs.AppUserDTOs
{
	public class AppUserRegisterDTO
	{
        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }
    }
}

