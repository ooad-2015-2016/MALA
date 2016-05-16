using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabavniPark.ZabavniPark.Models;
namespace ZabavniPark.ZabavniPark.Models
{
    class DefaultPodaci
    {
        public enum StanjeAtrakcije { Operating, NotOperating };
        public enum TipOsoblja { Radnik, SalterRadnik, Administrator };
       // public enum TipPosjetilaca { Obicni, Registrovani, Gold }
        public static void Initialize(ZabavniParkDbContext context)
        {
            if (!context.Atrakcije.Any())
            {
                context.Atrakcije.AddRange(new MyApp_OOAD.AtrakcijaBaza.Models.Atrakcija()
                {
              
                    Naziv = "Voz smrti",
                    Kapacitet = 200,
                    VrijemeOtvaranja = TimeSpan.Zero,
                    VrijemeZatvaranja = TimeSpan.Zero,
                    TrenutniBrojPosjetilaca = 56,
                    Stanje = MyApp_OOAD.AtrakcijaBaza.Models.StanjeAtrakcije.Operating,
                    TrajanjeVoznje = 15
                });
            }
            if (!context.Radnici.Any())
            {
                context.Radnici.AddRange(new MyApp_OOAD.ParkBaza.Models.Radnik()
                {
                    Ime = "Milan",
                    Prezime = "Zuza",
                    Tip = MyApp_OOAD.ParkBaza.Models.TipOsoblja.Administrator,
                    Username = "mzuza1",
                    Password = "zmilan1",
                    RadniStaz = 5,
                    Plata = 1200
                });
            }

            if (!context.Posjetioci.Any())
            {
                context.Posjetioci.AddRange(new Posjetilac()
                {
                    Ime = "Adnan",
                    Prezime = "Dzelihodzic",
                    Tip = TipPosjetilaca.Gold

                });
            }
            context.SaveChanges();
        }
    }
}