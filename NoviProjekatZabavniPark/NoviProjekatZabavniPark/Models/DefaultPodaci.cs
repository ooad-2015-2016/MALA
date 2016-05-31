using System;
using System.Collections.Generic;
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
                    new Atrakcija(0, "Cryptzone", 100, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0,
                    StanjeAtrakcije.Operating, 2, 43.856595, 18.395058),

                    new Atrakcija(1, "Dreamwille", 150, new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0), 0,
                    StanjeAtrakcije.Operating, 2, 43.857239, 18.395203),

                    new Atrakcija(2, "FunDome", 75, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0,
                    StanjeAtrakcije.Operating, 10, 43.856908, 18.396357),

                    new Atrakcija(3, "Phantomtown", 50, new TimeSpan(10, 0, 0), new TimeSpan(18, 0, 0), 0,
                    StanjeAtrakcije.Operating, 3, 43.857334, 18.396572),

                    new Atrakcija(4, "Shockland", 10, new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0), 0,
                    StanjeAtrakcije.Operating, 2, 43.855988, 18.396926),

                    new Atrakcija(5, "GhostParadise", 50, new TimeSpan(14, 0, 0), new TimeSpan(24, 0, 0),
                    0, StanjeAtrakcije.Operating, 7, 43.855709, 18.397752),

                    new Atrakcija(6, "Evertown", 30, new TimeSpan(10, 0, 0), new TimeSpan(20, 0, 0), 0,
                    StanjeAtrakcije.Operating, 3, 43.856073, 18.398567),

                    new Atrakcija(7, "PlayRealm", 100, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0,
                    StanjeAtrakcije.Operating, 3, 43.856676, 18.398234)
                );
            }

            //if (!context.Radnici.Any())
            //{
            //    context.AddRange
            //}

        }
    }
}
