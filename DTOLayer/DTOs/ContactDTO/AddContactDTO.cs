using System;
namespace DTOLayer.DTOs.ContactDTO
{
	public class AddContactDTO
	{
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string? UserName { get; set; }
        public bool Responsed { get; set; }

    }
}

