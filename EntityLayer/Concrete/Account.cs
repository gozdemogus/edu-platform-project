using System;
namespace BaseIdentity.EntityLayer.Concrete
{
	public class Account
	{
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}

