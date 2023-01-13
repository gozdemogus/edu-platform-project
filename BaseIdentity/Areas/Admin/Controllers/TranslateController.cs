using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BaseIdentity.PresentationLayer.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = "Admin")]
    public class TranslateController : Controller
    {

        private readonly IConfiguration _configuration;

        public TranslateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string keyword, string from, string to)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://long-translator.p.rapidapi.com/translate"),
                Headers =
    {
        { "X-RapidAPI-Key", "d80a8a96b9msh79c2f2fa5dedc03p1a4e44jsn8ee7fee646a7" },
        { "X-RapidAPI-Host", "long-translator.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "source_language", "auto" },
        { "target_language", to },
        { "text", keyword },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Root>(body);

                ViewBag.tr = values.data.translatedText;
                return View();

            }


        }


      
            public class Data
            {
                public string translatedText { get; set; }
                public DetectedSourceLanguage detectedSourceLanguage { get; set; }
            }

            public class DetectedSourceLanguage
            {
                public string code { get; set; }
                public string name { get; set; }
            }

            public class Root
            {
                public string status { get; set; }
                public Data data { get; set; }
            }

  

    }
}

