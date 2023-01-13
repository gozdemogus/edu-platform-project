using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.PresentationLayer.Models
{
	public class InAccountResetPasswordViewModel
	{
      
        [Required(ErrorMessage = "Type existing password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Type new password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Passwords must match")]
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }

    }
}

