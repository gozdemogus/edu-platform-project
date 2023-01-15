using System;
using APIPayment.DAL.Entities;

namespace APICampaign.DAL.Entities
{
	public class CampaignAssignee
	{
		public int Id { get; set; }
        public int UserId { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}

