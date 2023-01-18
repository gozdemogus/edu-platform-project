using System;
using System.ComponentModel.DataAnnotations;

namespace BaseIdentity.EntityLayer.Concrete
{
	public class Notification
	{
		[Key]
		public int Id { get; set; }
		public DateTime DateTime { get; set; }
		public string Message { get; set; }
		public string? MessageWriter { get; set; }
	}
}

