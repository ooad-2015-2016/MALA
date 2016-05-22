using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public enum TipOsoblja { RadnikTeren, SalterRadnik, Administrator };

    public class Administrator : Korisnik
    {
        TipOsoblja Tip { get; set; }
        public Administrator(int id, string ime, string prezime, TipOsoblja tip, string username, string pass, int god, double plata)
            : base(id, username, pass, ime, prezime, god, plata)
        {
            Tip = TipOsoblja.Administrator;
        }
    }
}
