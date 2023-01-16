using System;
using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOs.AppUserDTOs
{
	public class AppUserLoginDTO
	{
        public string username { get; set; }

        public string password { get; set; }
    }
}

