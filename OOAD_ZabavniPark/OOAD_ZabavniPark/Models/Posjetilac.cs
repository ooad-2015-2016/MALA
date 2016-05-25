using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public class Posjetilac : Korisnik
    {
        #region Properties
        public DateTime DatumRodjenja { get; set; }
        public string EMail { get; set; }
        public List<Karta> KupljeneKarte { get; set; }
        #endregion

        #region Konstruktori

        public Posjetilac():base() { }
    
        public Posjetilac(int id, string ime, string prezime, DateTime datum, string username, string password,  string email, List<Karta> karte)
            :base(id, username, password, ime, prezime)
        {
            DatumRodjenja = datum;
            EMail = email;
            KupljeneKarte = new List<Karta>(karte);
        }

        public Posjetilac(Posjetilac p) : base(p.ID, p.KorisnickoIme, p.Sifra, p.Ime, p.Prezime)
        {
            DatumRodjenja = p.DatumRodjenja;
            EMail = p.EMail;
            KupljeneKarte = new List<Karta>(p.KupljeneKarte);
        }
        #endregion
    }
}
