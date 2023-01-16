using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;


        public CampaignController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Campaign");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CampaignViewModel>>(jsonData);
                return View(values); 
            }
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCampaign()
        {
            ViewBag.Users = await _userManager.Users.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCampaign(CampaignViewModel campaignViewModel)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(campaignViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:5001/api/Campaign", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var url = Url.RouteUrl("areas", new { controller = "Campaign", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:5001/api/Campaign/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var url = Url.RouteUrl("areas", new { controller = "Campaign", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:5001/api/Campaign/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CampaignViewModel>(jsonData);
                 return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CampaignViewModel campaignViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(campaignViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:5001/api/Campaign", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var url = Url.RouteUrl("areas", new { controller = "Campaign", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            else
            {
                return View();
            }
        }


    }
}

