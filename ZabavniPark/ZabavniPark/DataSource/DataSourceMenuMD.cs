using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabavniPark.ZabavniPark.Models;
using ZabavniPark.ZabavniPark.Views;

namespace ZabavniPark.DataSource
{
    //Klasa koja predstavlja sloj podataka
    public class DataSourceMenuMD
    {
        #region Korisnik - kreiranje testnih korisnika
        private static List<Korisnik> _korisnici = new List<Korisnik>()
 {
 new Korisnik()
 {
 KorisnikId=1,
 KorisnickoIme="administrator",
 Sifra="1234",
 },
 new Korisnik()
 {
 KorisnikId=2,
 KorisnickoIme="osnovni",
 Sifra="1234"
 }
 };
        public static IList<Korisnik> DajSveKorisnike()
        {
            return _korisnici;
        }
        public static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return _korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }
        public static Korisnik ProvjeraKorisnika(string korisnickoIme, string sifra)
        {
            Korisnik rezultat = new Korisnik();
            foreach (var k in DajSveKorisnike())
            {
                if (k.KorisnickoIme == korisnickoIme && k.Sifra == sifra) rezultat = k;
            }
            return rezultat;
        }
        #endregion
        #region Uloga - kreiranje testnih uloga
        private static List<Uloga> _uloge = new List<Uloga>()
             {
             new Uloga()
             {
             UlogaId=1,
            Naziv="Administrator",
             },
             new Uloga()
             {
             UlogaId=2,
             Naziv="Registrovani korisnik",
             }
             };
        public static IList<Uloga> DajSveUloge()
        {
            return _uloge;
        }
        public static Uloga DajUloguPoId(int ulogaId)
        {
            return _uloge.Where(k => k.UlogaId.Equals(ulogaId)).FirstOrDefault();
        }
        #endregion
        #region MeniStavka - kreiranje novih meni stavki
        private static List<MeniStavka> _meniStavke = new List<MeniStavka>()
                 {
                 new MeniStavka()
                 {
                 MeniStavkaId=1,
                Naziv="Unos atrakcija",
                Kod="F1",
                Podstranica = typeof(AtrakcijaUnos)
                 },
                 new MeniStavka()
                 {
                 MeniStavkaId=2,
                Naziv="Unos osoblja",
                 Kod="F2",
                 Podstranica = typeof(RadnikUnos)
                 }/*,
                 
                   
                   new MeniStavka()
                 {
                 MeniStavkaId=3,
                Naziv="Unos Posjetilaca",
                Kod="F3",
                 Podstranica = typeof(PosjetilacUnos)
                 },*/
                 
                 };
        public static IList<MeniStavka> DajSveMeniStavke()
        {
            return _meniStavke;
        }
        public static MeniStavka DajMeniStavkuPoId(int meniStavkaId)
        {
            return _meniStavke.Where(k => k.MeniStavkaId.Equals(meniStavkaId)).FirstOrDefault();
        }
        #endregion
        #region Inicijalna postavka uloga i stavki
        public DataSourceMenuMD()
        {
            Korisnik k1 = DajKorisnikaPoId(1);
            Korisnik k2 = DajKorisnikaPoId(2);
            Uloga u1 = DajUloguPoId(1);
            Uloga u2 = DajUloguPoId(2);
            MeniStavka ms1 = DajMeniStavkuPoId(1);
            MeniStavka ms2 = DajMeniStavkuPoId(2);
            MeniStavka ms3 = DajMeniStavkuPoId(3);
            //Dodavanje stavki ulozi i uloge korisniku 1
            u1.DodajMeniStavkuUlozi(ms1);
            u1.DodajMeniStavkuUlozi(ms2);
            u1.DodajMeniStavkuUlozi(ms3);
            k1.DodajUloguKorisnika(u1);
            //Dodavanje stavki ulozi i uloge korisniku 2
            k2.DodajUloguKorisnika(u2);
        }
        #endregion
    }

}
