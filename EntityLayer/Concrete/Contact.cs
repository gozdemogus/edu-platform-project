using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class Contact
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public string Email { get; set; }
        public DateTime Date { get; set; }
        public string? UserName { get; set; }

	}
}

