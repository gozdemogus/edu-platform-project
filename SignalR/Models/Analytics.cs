using System;
namespace SignalR.Models
{
	public class Analytics
	{
		public Analytics()
		{
		}

        public int Id { get; set; }
        public int Customers { get; set; }
        public int Orders { get; set; }
        public string Conversion { get; set; }
        public string Earnings { get; set; }
    }
}

