using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public enum TipOsoblja { RadnikTeren, SalterRadnik, Administrator };

    public class Radnik : Korisnik
    {
        #region Properties
        public int RadniStaz { get; set; }
        public double Plata { get; set; }
        public TipOsoblja Tip { get; set; }
        #endregion

        #region Konstruktori
        public Radnik(int id, string ime, string prezime, TipOsoblja tip, string username, string pass, int godStaza, double plata)
            : base(id, username, pass, ime, prezime)
        {
            RadniStaz = godStaza;
            Plata = plata;
            Tip = tip;
        }

        public Radnik(Radnik r) : base(r.KorisnikId, r.KorisnickoIme, r.Sifra, r.Ime, r.Prezime)
        {
            Plata = r.Plata;
            RadniStaz = r.RadniStaz;
            Tip = r.Tip;
        }
        #endregion

    }
}
