using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BaseIdentity.PresentationLayer.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SearchController : Controller
    {

        private readonly IConfiguration _configuration;

        public SearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string keyword)
        {
            string apiKey = _configuration["MyApiKey"];
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://bing-web-search1.p.rapidapi.com/search?q={keyword}&mkt=en-us&safeSearch=Off&textFormat=Raw&freshness=Day"),
                Headers =
            {
                { "X-BingApis-SDK", "true" },
                { "X-RapidAPI-Key", "d80a8a96b9msh79c2f2fa5dedc03p1a4e44jsn8ee7fee646a7" },
                { "X-RapidAPI-Host", "bing-web-search1.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                SearchResponse response2 = System.Text.Json.JsonSerializer.Deserialize<SearchResponse>(body);


                List<WebPage> webPageList = new List<WebPage>();
                foreach (WebPage webPage in response2.webPages.value)
                {
                    webPageList.Add(webPage);
                }


                return View(webPageList);
            }
        }
    }
}


