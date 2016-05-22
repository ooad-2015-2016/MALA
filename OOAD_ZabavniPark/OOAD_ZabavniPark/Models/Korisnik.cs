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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int RadniStaz { get; set; }
        public double Plata { get; set; }

       // public DateTime? DatumVrijemeZadnjegPristupa { get; set; }
       // public bool? Aktivan { get; set; }


        public Korisnik(Korisnik k)
        {
            KorisnikId = k.KorisnikId;
            KorisnickoIme = k.KorisnickoIme;
            Sifra = k.Sifra;
            Ime = k.Ime;
            Prezime = k.Prezime;
            RadniStaz = k.RadniStaz;
            Plata = k.Plata;
        }

        public Korisnik(int ID, string username, string password, string ime, string prezime, int radniStaz, double plata)
        {
            KorisnikId = ID;
            KorisnickoIme = username;
            Sifra = password;
            Ime = ime;
            Prezime = prezime;
            RadniStaz = radniStaz;
            Plata = plata;
        }
    }
}
