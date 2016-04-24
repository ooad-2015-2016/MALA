using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
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
    class PosjetilacDbContext: DbContext
    {
        public DbSet<Posjetilac> Posjetioci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dataBaseFilePath = "PosjetiociBaza.db";
            try
            {
                dataBaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dataBaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={dataBaseFilePath}");
        }

    }
}
