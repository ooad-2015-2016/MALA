using MyApp_OOAD.ParkBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.ZabavniPark.Models
{
    class DefaultPodaci
    {
        public static void Initialize(ParkDbContext context)
        {
            if (!context.Parkovi.Any())
            {
                context.Parkovi.AddRange(
                new Park()
                {
                    Naziv = "Park 1",
                    Kapacitet = 10000,
                    TrenutniBrojPosjetilaca = 1000,
                    BrojRadnika = 250,
                    Atrakcije = new List<string>() {"Atrakcija 1", "Atrakcija 2", "Atrakcija 3", "Atrakcija 4" }
                }
                );
                context.SaveChanges();
            }
        }
    }

}
