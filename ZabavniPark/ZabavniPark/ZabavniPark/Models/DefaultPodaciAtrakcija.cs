using MyApp_OOAD.AtrakcijaBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.ZabavniPark.Models
{
    class DefaultPodaciAtrakcija
    {
        public static void Initialize(AtrakcijaDbContext context)
        {
            if (!context.SveAtrakcije.Any())
            {
                context.SveAtrakcije.AddRange(
                new Atrakcija()
                {
                    Naziv = "Eurosat",
                    Kapacitet = 300,
                    VrijemeOtvaranja = new TimeSpan(9, 0, 0),
                    VrijemeZatvaranja = new TimeSpan(20, 0, 0),
                    TrenutniBrojPosjetilaca = 475,
                    Stanje = StanjeAtrakcije.Operating,
                    Cijena = 5,
                    BrojNaCekanju = 175
                }
                );
                context.SaveChanges();
            }
        }
    }
}