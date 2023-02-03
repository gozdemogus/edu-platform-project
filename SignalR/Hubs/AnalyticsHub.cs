using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class AnalyticsHub : Hub
    {
        private readonly AnalyticsUpdateService _analyticsUpdateService;
        private readonly Context _context;
        private readonly Random _random;

        public AnalyticsHub(AnalyticsUpdateService service, Context context, Random random)
        {
            _analyticsUpdateService = service;
            _context = context;
            _random = random;

        }

        public async Task DataForAll()
        {
            try
            {
                while (true)
                {

                    await GetAnalytics();
                    await GetTrafficSources();
                    await RandomChartValues();
                    await GetBitcoinPrice();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Send", ex.Message + "\n" + ex.StackTrace);
            }
        }

        public async Task RandomChartValues()
        {
            int Min = 10;
            int Max = 100;
            Random randNum = new Random();
            int[] test2 = Enumerable
                .Repeat(0, 5)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();

             string[] words1 = new string[] { "C#", "Java", "PHP", "JavaScript", "Kotlin", "Swift", "Go", "Rust", "Python", "C++"};

            var shuffleNames = Shuffle(words1);

            await Clients.All.SendAsync("ChartValues", test2, shuffleNames);
            System.Threading.Thread.Sleep(2000);
        }

        public string[] Shuffle(string[] wordArray)
        {
            Random random = new Random();
            for (int i = wordArray.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                string temp = wordArray[i];
                wordArray[i] = wordArray[swapIndex];
                wordArray[swapIndex] = temp;
            }
            return wordArray;
        }

        public async Task GetAnalytics()
        {

            _analyticsUpdateService.UpdateAnalytics();
            var analytics = _context.Analytics.FirstOrDefault(a => a.Id == 1);
          
            await Clients.All.SendAsync("ReceiveAnalytics", analytics);
          //  System.Threading.Thread.Sleep(1000);

        }

        public async Task GetTrafficSources()
        {
            var trafficSources = _context.TrafficSources.ToList();
            UpdateTrafficSourcesRandomly(trafficSources);
            var totalCount = CalculateTotalTrafficSources(trafficSources);
            var goal = Math.Round(totalCount * 2.65, 1) ;
            await Clients.All.SendAsync("ReceiveTrafficSources", trafficSources, totalCount, goal);
         //   System.Threading.Thread.Sleep(1000);
        }

        public void UpdateTrafficSourcesRandomly(List<TrafficSource> trafficSources)
        {
            var colors = new List<string> { "danger", "info", "primary", "warning", "success", "dark" };

            foreach (var source in trafficSources)
            {
                source.Total = _random.Next(0, 1000);
                int index = _random.Next(0, colors.Count);
                source.Color = colors[index];
                colors.RemoveAt(index);
            }
        }

        public int CalculateTotalTrafficSources(List<TrafficSource> trafficSources)
        {
            int total = 0;
            foreach (var source in trafficSources)
            {
                total += source.Total;
            }
            return total;
        }

        public async Task GetBitcoinPrice()
        {
            // Make API request to CoinDesk
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.coindesk.com/v1/bpi/currentprice.json");
                var response = await client.GetAsync("");
                var result = await response.Content.ReadAsStringAsync();

               
                dynamic data = JsonConvert.DeserializeObject(result);
                string price = data.bpi.USD.rate;

            
                await Clients.All.SendAsync("ReceiveBitcoinPrice", price);
            }
        }

    }



}


