using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseIdentity.EntityLayer.Concrete;
using System.Net.Http;
using BaseIdentity.DataAccessLayer.Concrete;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using BaseIdentity.PresentationLayer.Models;
using System.Collections.Generic;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Coupons:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public Coupons(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:5005/api/Campaign/api/Campaign/ListForCustomer");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CampaignViewModel>>(jsonData);

                return View(result);
            }
            else
            {
                return View();
            }
        }
    }
}

