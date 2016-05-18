using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniPark.ZabavniPark.DataSource
{
    public class DataSourcePark
    {
        private static List<Korisnik> korisnici = new List<Korisnik>()
        {
            new Korisnik()
            {
                KorisnikId = 0,
                KorisnickoIme = "admin",
                Sifra = "adminpass"
            },
            new Korisnik()
            {
                KorisnikId = 1,
                KorisnickoIme = "mmujic1",
                Sifra = "12345"
            }
        };

       

        
        public static IList<Korisnik> DajSveKorisnike() { return korisnici; }

        public static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }

        public static Korisnik ProvjeraKorisnika(string korisnickoIme, string sifra)
        {
            Korisnik rezultat = null;
            foreach (var k in DajSveKorisnike())
            {
                if (k.KorisnickoIme == korisnickoIme && k.Sifra == sifra) { rezultat = new Korisnik(k); }
            }
            return rezultat;
        }





    }
}
