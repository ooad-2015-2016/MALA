using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public class Korisnik
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        #endregion

        #region Konstruktori
        public Korisnik(Korisnik k)
        {
            KorisnikId = k.KorisnikId;
            KorisnickoIme = k.KorisnickoIme;
            Sifra = k.Sifra;
            Ime = k.Ime;
            Prezime = k.Prezime;
        }

        public Korisnik(int ID, string username, string password, string ime, string prezime)
        {
            KorisnikId = ID;
            KorisnickoIme = username;
            Sifra = password;
            Ime = ime;
            Prezime = prezime;
        }
        #endregion
    }
}
