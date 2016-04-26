using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZabavniPark.ZabavniPark.Models
{
    class OsobljeDefaultPodaci
    {
        public static void Initialize(MyApp_OOAD.AtrakcijaBaza.Models.OsobljeDbContext context)
        {
            if (!context.Osoblje.Any())
            {
                context.Osoblje.AddRange(
                    new Osoblje()
                    {
                        ime = "Milan",
                        prezime = "Zuza",
                        tip = "Administrator",
                        username = "mzuza1",
                        password = "SerenaWilliams",
                        radniStaz = 15
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
