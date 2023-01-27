using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    public class GeographyContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        private string connectionString;
        public GeographyContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
