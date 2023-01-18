using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPayment.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpSchool_WebApi.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPayment.Controllers
{
    [EnableCors]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {


        [HttpGet]
        public IActionResult CampaignList()
        {
            using (var context = new Context())
            {
                var values = context.Campaigns.Include(c => c.CampaignAssignees).ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult CampaignAdd(Campaign campaign)
        {
            using (var context = new Context())
            {
                context.Add(campaign);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult CampaignGet(int id)
        {
            using (var context=new Context())
            {
                var values = context.Campaigns.Find(id);
                                 
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

        [HttpDelete("{id}")]
        public IActionResult DeleteCampaign(int id)
        {
            using (var context = new Context())
            {
                var values = context.Campaigns.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }


        [HttpPut]
        public IActionResult UpdateCampaign(Campaign campaign)
        {
            using (var context = new Context())
            {
                var values = context.Find<Campaign>(campaign.Id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                 //   values.CampaignAssignees = campaign.CampaignAssignees;
                    values.Code = campaign.Code;

                    values.CampaignName = campaign.CampaignName;
                    values.DiscountAmount = campaign.DiscountAmount;

                    if(campaign.StartDate != null)
                    {
                        values.StartDate = campaign.StartDate;
                    }
                  if(campaign.EndDate!= null)
                    {
                        values.EndDate = campaign.EndDate;
                    }
                
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}

