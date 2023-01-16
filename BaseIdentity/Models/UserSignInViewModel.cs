using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.PresentationLayer.Models
{
	public class UserSignInViewModel
	{
	[Required(ErrorMessage="Enter Username")]
		public string username { get; set; }

      [Required(ErrorMessage = "Enter Password")]
        public string password { get; set; }
	}
}

