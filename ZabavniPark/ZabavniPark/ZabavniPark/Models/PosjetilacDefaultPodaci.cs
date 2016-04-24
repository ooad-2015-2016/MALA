using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.ZabavniPark.Models
{
    class PosjetilacDefaultPodaci
    {
        public static void Initialize(PosjetilacDbContext context)
        {
            if(!context.Posjetioci.Any())
            {
                context.Posjetioci.AddRange(
                    new Posjetilac()
                    {
                        Ime = "Ime",
                        Prezime = "Prezime",
                        tip = TipPosjetilaca.Obicni
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
