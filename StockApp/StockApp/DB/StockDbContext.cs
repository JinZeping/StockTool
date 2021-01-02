using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApp.DB.Models;

namespace StockApp.DB
{
    public class StockDbContext : DbContext
    {
        public DbSet<Exchange> Exchange { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = .; Initial Catalog = StockDB; User ID = sa; Password = Zeping552779");
        }
    }
}
