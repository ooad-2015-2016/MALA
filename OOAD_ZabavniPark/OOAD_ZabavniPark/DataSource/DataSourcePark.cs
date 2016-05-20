using OOAD_ZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_ZabavniPark.DataSource
{
    public class DataSourcePark
    {
        private static List<Korisnik> korisnici = new List<Korisnik>()
        {
            new Administrator(1, "Admin", "Adminić", TipOsoblja.Administrator, "admin1","adminpass", 10, 1100),
            new Korisnik(2, "mmujic1", "12345", "Mujo", "Mujic", 5, 1000)
        };

        public static IList<Korisnik> DajSveKorisnike() { return korisnici; }

        public static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }

        public static Korisnik ProvjeraKorisnika(string korisnickoIme, string sifra)
        {
            List<Korisnik> korisnici = new List<Korisnik>(DajSveKorisnike());
            foreach (var k in korisnici)
            {
                if (k.KorisnickoIme == korisnickoIme && k.Sifra == sifra) { return k; }
            }
            return null;
        }
    }
}
