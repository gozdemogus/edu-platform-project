using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class AnalyticsUpdateService
    {
        private readonly Context _context;
        private readonly Random _random;

        public AnalyticsUpdateService(Context context, Random random)
        {
            _context = context;
            _random = random;
        }

        public void UpdateAnalytics()
        {
            var analytics = _context.Analytics.FirstOrDefault(a => a.Id == 1);
            if (analytics != null)
            {
                analytics.Customers = _random.Next(0, 1000);
                analytics.Orders = _random.Next(0, 1000);
                analytics.Conversion = _random.Next(0, 100) + "%";
                analytics.Earnings = "$" + _random.Next(0, 10000);
                _context.SaveChanges();
             
            }
        }
    }
}

