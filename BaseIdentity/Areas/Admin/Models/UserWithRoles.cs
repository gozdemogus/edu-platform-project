using System;
using BaseIdentity.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BaseIdentity.PresentationLayer.Areas.Admin.Models
{
	public class UserWithRoles
	{
        public AppUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}

