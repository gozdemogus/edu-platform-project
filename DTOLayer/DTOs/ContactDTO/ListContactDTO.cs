using System;
namespace DTOLayer.DTOs.ContactDTO
{
	public class ListContactDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string? UserName { get; set; }
        public bool Responsed { get; set; }
    }
}

