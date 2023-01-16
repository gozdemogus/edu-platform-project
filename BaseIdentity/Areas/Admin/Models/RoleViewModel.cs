using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.PresentationLayer.Areas.Admin.Models
{
	public class RoleViewModel
	{
        [Required(ErrorMessage = "Provide Role Name")]
        public string RoleName { get; set; }
    }
}

