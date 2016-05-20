using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_ZabavniPark.Models
{
    public class Radnik : Korisnik
    {
        public TipOsoblja Tip { get; set; }

        public Radnik(int id, string ime, string prezime, TipOsoblja tip, string username, string pass, int god, double plata)
            : base(id, username, pass, ime, prezime, god, plata)
        {
            Tip = tip;
        }
    }
}
