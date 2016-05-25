using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OOADZabavniPark.Models
{
    public class ZabavniParkDbContext : DbContext
    {
        public DbSet<Atrakcija> Atrakcije { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Posjetilac> Posjetioci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "ZabavniPark.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
