using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
    public class Radnik : Korisnik
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RadnikId { get; set; }
        public int RadniStaz { get; set; }
        public double Plata { get; set; }
        public TipOsoblja Tip { get; set; }
        #endregion

        #region Konstruktori
        public Radnik() { }
       
        public Radnik(string ime, string prezime, TipOsoblja tip, string username, string pass, int godStaza, double plata)
            : base(username, pass, ime, prezime)
        {
            RadniStaz = godStaza;
            Plata = plata;
            Tip = tip;
        }

        public Radnik(Radnik r) : base(r.KorisnickoIme, r.Sifra, r.Ime, r.Prezime)
        {
            Plata = r.Plata;
            RadniStaz = r.RadniStaz;
            Tip = r.Tip;
        }
        #endregion

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

    }
}
