using System;
namespace HotelAPI.DAL.Entities
{
	public class Credit
	{
		public Credit()
		{
		}


        public int Id { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
    }
}

