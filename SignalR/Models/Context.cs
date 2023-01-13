using System;
using Microsoft.EntityFrameworkCore;

namespace SignalR.Models
{
	public class Context:DbContext
	{
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        public DbSet<Analytics> Analytics { get; set; }
        public DbSet<WebAudienceMetrics> WebAudienceMetrics { get; set; }
        public DbSet<TrafficSource> TrafficSources { get; set; }

    }
}

