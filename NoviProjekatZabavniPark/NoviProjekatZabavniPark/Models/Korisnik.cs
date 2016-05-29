using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
    public class Korisnik
    {
        #region Properties
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        #endregion

        #region Konstruktori
        public Korisnik(Korisnik k)
        {
            KorisnickoIme = k.KorisnickoIme;
            Sifra = k.Sifra;
            Ime = k.Ime;
            Prezime = k.Prezime;
        }
        public Korisnik()
        {

        }
        public Korisnik(string username, string password, string ime, string prezime)
        {
            KorisnickoIme = username;
            Sifra = password;
            Ime = ime;
            Prezime = prezime;
        }
        #endregion
    }
}
