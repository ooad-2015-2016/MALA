using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.ZabavniPark.Models
{

    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }

        public string Sifra { get; set; }
        public DateTime? DatumVrijemeZadnjegPristupa { get; set; }
        public bool? Aktivan { get; set; }
        public virtual ICollection<UlogaKorisnik> UlogaKorisnika //Predstavlja listu korisničkih uloga
        {
            get;
            set;
        }
        public Korisnik()
        {
            UlogaKorisnika = new List<UlogaKorisnik>();
        }
        public Korisnik(Korisnik k)
        {
            KorisnickoIme = k.KorisnickoIme;
            k.Sifra = k.Sifra;
        }

        public Korisnik(string username, string password)
        {
            KorisnickoIme = username;
            Sifra = password;
        }
        //dodavanje uloga korisniku
        public void DodajUloguKorisnika(Uloga uloga)
        {
            this.UlogaKorisnika.Add(new UlogaKorisnik(uloga, this));
        }
    }
}
