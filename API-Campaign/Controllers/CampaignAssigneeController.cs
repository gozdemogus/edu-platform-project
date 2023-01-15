using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICampaign.DAL.Entities;
using APIPayment.DAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSchool_WebApi.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICampaign.Controllers
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignAssigneeController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult CampaignGetByUser(int id)
        {
            using (var context = new Context())
            {
                var values = context.Campaigns.Include(c => c.CampaignAssignees)
                                .Where(c => c.CampaignAssignees.Any(ca => ca.UserId == id))
                                //  && c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now)
                                .ToList();
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }

        [HttpPost]
        public IActionResult AssignCampaignToUser(int campaignId, int userId)
        {
            using (var context = new Context())
            {
                var campaign = context.Campaigns.Find(campaignId);
                if (campaign == null)
                {
                    return NotFound("Campaign not found");
                }
                var user = context.CampaignAssignee.Find(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                var campaignAssignee = new CampaignAssignee
                {
                    UserId = userId,
                    CampaignId = campaignId
                };
                context.CampaignAssignee.Add(campaignAssignee);
                context.SaveChanges();
                return Ok("Campaign assigned to user successfully");
            }
        }

        [HttpDelete]
        public IActionResult UnassignCampaignFromUser(int campaignId, int userId)
        {
            using (var context = new Context())
            {
                var campaignAssignee = context.CampaignAssignee.FirstOrDefault(ca => ca.CampaignId == campaignId && ca.UserId == userId);
                if (campaignAssignee == null)
                {
                    return NotFound("Assignment not found");
                }
                context.CampaignAssignee.Remove(campaignAssignee);
                context.SaveChanges();
                return Ok("Campaign unassigned from user successfully");
            }
        }

        [HttpPut("change")]
        public IActionResult ChangeUserCampaign(int userId, int oldCampaignId, Campaign newCampaign)
        {
            using (var context = new Context())
            {
                var user = context.CampaignAssignee.Find(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                var oldCampaignAssignee = context.CampaignAssignee.FirstOrDefault(ca => ca.UserId == userId && ca.CampaignId == oldCampaignId);
                if (oldCampaignAssignee == null)
                {
                    return NotFound("Assignment not found");
                }
                var newCampaignAssignee = new CampaignAssignee
                {
                    UserId = userId,
                    CampaignId = newCampaign.Id
                };
                context.CampaignAssignee.Remove(oldCampaignAssignee);
                context.CampaignAssignee.Add(newCampaignAssignee);
                context.SaveChanges();
                return Ok("User campaign changed successfully");
            }
        }

    }
}

