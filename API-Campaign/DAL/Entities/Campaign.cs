using System;
using APICampaign.DAL.Entities;
using System.Collections.Generic;

namespace APIPayment.DAL.Entities
{
	public class Campaign
	{
		public Campaign()
		{
		}

		public int Id { get; set; }
	
		public string Code { get; set; }
		public int DiscountAmount { get; set; }
		public string CampaignName { get; set; }
		public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CampaignAssignee> CampaignAssignees { get; set; }

    }
}

