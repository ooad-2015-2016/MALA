using Microsoft.Data.Entity;
using MyApp_OOAD.AtrakcijaBaza.Models;
using MyApp_OOAD.ParkBaza.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ZabavniPark.ZabavniPark.Models
{
    public class ZabavniParkDbContext : DbContext
    {
        public DbSet<Atrakcija> Atrakcije { get; set; }
        public DbSet<Osoblje> Osoblja { get; set; }
        public DbSet<Posjetilac> Posjetioci { get; set;  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Ooadbaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
