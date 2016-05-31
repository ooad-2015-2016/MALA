using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
    public class DefaultPodaci
    {
        public static void Initialize(ZabavniParkDbContext context)
        {
            if (!context.Atrakcije.Any())
            {
                context.AddRange
                (
                    new Atrakcija("Cryptzone", 100, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0,
                    StanjeAtrakcije.Operating, 2, 43.856595, 18.395058),

                    new Atrakcija("Dreamwille", 150, new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0), 0,
                    StanjeAtrakcije.Operating, 2, 43.857239, 18.395203),

                    new Atrakcija("FunDome", 75, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0,
                    StanjeAtrakcije.Operating, 10, 43.856908, 18.396357),

                    new Atrakcija("Phantomtown", 50, new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0), 0,
                    StanjeAtrakcije.Operating, 3, 43.857334, 18.396572),

                    new Atrakcija("Shockland", 10, new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0), 0,
                    StanjeAtrakcije.Operating, 2, 43.855988, 18.396926),

                    new Atrakcija("GhostParadise", 50, new TimeSpan(14, 0, 0), new TimeSpan(24, 0, 0),
                    0, StanjeAtrakcije.Operating, 7, 43.855709, 18.397752),

                    new Atrakcija("Evertown", 30, new TimeSpan(10, 0, 0), new TimeSpan(20, 0, 0), 0,
                    StanjeAtrakcije.Operating, 3, 43.856073, 18.398567),

                    new Atrakcija("PlayRealm", 100, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0,
                    StanjeAtrakcije.Operating, 3, 43.856676, 18.398234)
                );
                context.SaveChanges();
            }

            if (!context.Radnici.Any())
            {
                context.AddRange(
                    new Radnik()
                    {
                        Ime = "Ajša",
                        Prezime = "Terko",
                        Tip = TipOsoblja.RadnikSalter,
                        KorisnickoIme = "aterko1",
                        Sifra = "123",
                        RadniStaz = 5,
                        Plata = 1500
                    },
                     new Radnik()
                     {
                         Ime = "Lejla",
                         Prezime = "Zečević",
                         Tip = TipOsoblja.RadnikSalter,
                         KorisnickoIme = "lzecevic1",
                         Sifra = "123",
                         RadniStaz = 5,
                         Plata = 1500
                     });
                context.SaveChanges();
            }

            if (!context.Posjetioci.Any())
            {
                List<Karta> karte = new List<Karta>();
                karte.Add(new Karta(new DateTime(2016, 6, 16), TipKarte.StandardOdrasli));

                context.AddRange(
                    new Posjetilac("Ime", "Prezimović", new DateTime(1995, 5, 5), "iprez1", "1234", "ime.prez@gmail.com",
                    new List<Karta>(karte)));
                context.SaveChanges();
            }


            if (!context.Karte.Any())
            {
                context.AddRange(
                    new Karta()
                    {
                        Datum = new DateTime(2016, 6, 16),
                        Tip = TipKarte.StandardOdrasli
                    },
                    new Karta()
                    {
                        Datum = new DateTime(2016, 6, 18),
                        Tip = TipKarte.StandardOdrasli
                    });

                context.SaveChanges();
            }
        }
    }
}
