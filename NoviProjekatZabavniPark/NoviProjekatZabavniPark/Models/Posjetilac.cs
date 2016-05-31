using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
    public class Posjetilac : Korisnik
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PosjetilacId { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string EMail { get; set; }
        public List<Karta> KupljeneKarte { get; set; }
        #endregion

        #region Konstruktori

        public Posjetilac() : base() { }

        public Posjetilac(string ime, string prezime, DateTime datum, string username, string password, string email, List<Karta> karte)
            : base(username, password, ime, prezime)
        {
            DatumRodjenja = datum;
            EMail = email;
            KupljeneKarte = new List<Karta>(karte);
        }

        public Posjetilac(Posjetilac p) : base(p.KorisnickoIme, p.Sifra, p.Ime, p.Prezime)
        {
            DatumRodjenja = p.DatumRodjenja;
            EMail = p.EMail;
            KupljeneKarte = new List<Karta>(p.KupljeneKarte);
        }
        #endregion
    }
}
