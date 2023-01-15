using APIPayment.DAL.Entities;
using HotelAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace UpSchool_WebApi.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=Education-API;MultipleActiveResultSets=true;User=SA;Password=MyPass@word;");
        }

        public DbSet<Credit> Credits { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

    }
}
