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
                    TrajanjeVoznje=100
                });
            }
            if (!context.Osoblja.Any())
            {
                context.Osoblja.AddRange(new MyApp_OOAD.ParkBaza.Models.Osoblje()
                {
                    ime = "Milan",
                    prezime = "Zuza",
                    tip = MyApp_OOAD.ParkBaza.Models.TipOsoblja.Administrator,
                    username = "mzuza1",
                    password = "zmilan1",
                    radniStaz = 5
                });
            }

            if (!context.Posjetioci.Any())
            {
                context.Posjetioci.AddRange(new Posjetilac()
                {
                    Ime = "Adnan",
                    Prezime = "Dzelihodzic",
                    tip = TipPosjetilaca.Gold

                });
            }
            context.SaveChanges();


        }
    }
}