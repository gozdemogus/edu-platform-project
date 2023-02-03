using System;
namespace BaseIdentity.PresentationLayer.Models
{
	public class CampaignViewModel
    {
        public string code { get; set; }
        public int discountAmount { get; set; }
        public string campaignName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}

