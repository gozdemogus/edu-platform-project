using System;
namespace BaseIdentity.PresentationLayer.Areas.Admin.Models
{
	public class CampaignViewModel
	{
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountAmount { get; set; }
        public string CampaignName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}

