using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OOAD_ZabavniPark.Models
{
    public class ZabavniParkDbContext : DbContext
    {
        public DbSet<Atrakcija> Atrakcije { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        // ovdje treba biti DbSet<Korisnik> Korisnici { get; set; } koja se odnosi na korisnike sistema
        public DbSet<Posjetilac> Posjetioci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "ParkBaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
