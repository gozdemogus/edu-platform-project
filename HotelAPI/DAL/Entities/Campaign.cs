using System;
namespace APIPayment.DAL.Entities
{
	public class Campaign
	{
		public Campaign()
		{
		}

		public int Id { get; set; }
		public int UserId { get; set; }
		public string Code { get; set; }
		public int DiscountAmount { get; set; }
		public int CampaignName { get; set; }
		public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}

