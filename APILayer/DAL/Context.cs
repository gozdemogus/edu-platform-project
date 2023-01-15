using System;
using APILayer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace APILayer.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=API-EDU;MultipleActiveResultSets=true;User=SA;Password=MyPass@word;");
        }


        public DbSet<Credit> Credits { get; set; }

    }
}

