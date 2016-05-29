using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
    public class Administrator : Korisnik
    {
        public int AdministratorId { get; set; }
        public int RadniStaz { get; set; }
        public double Plata { get; set; }

        public Administrator(int id, string ime, string prezime, string username, string pass, int godStaza, double plata)
            : base(username, pass, ime, prezime)
        {
            AdministratorId = id;
            RadniStaz = godStaza;
            Plata = plata;
        }
    }
}
