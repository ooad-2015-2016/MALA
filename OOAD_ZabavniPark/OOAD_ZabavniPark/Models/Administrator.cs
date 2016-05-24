using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public class Administrator : Korisnik
    {
        //TipOsoblja Tip { get; set; } tip osoblja treba promijeniti, tako da nema polje administrator, posto je to vec klasa za sebe
        public int RadniStaz { get; set; }
        public double Plata { get; set; }

        public Administrator(int id, string ime, string prezime, string username, string pass, int godStaza, double plata)
            : base(id, username, pass, ime, prezime)
        {
            RadniStaz = godStaza;
            Plata = plata;
        }
    }
}

