﻿using OOADZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.DataSource
{
    public class DataSourcePark
    {
        private static List<Korisnik> korisnici = new List<Korisnik>()
        {
            new Administrator(1, "Admin", "Adminić", "admin1","adminpass", 10, 1100),
            new Radnik(2, "Mujo", "Mujić", TipOsoblja.SalterRadnik, "mmujic1", "12345",  5, 1000),
            new Posjetilac(3, "Pero", "Perić", new DateTime(1996, 3, 5), "123456789", "pperic1", "123", TipPosjetilaca.Regular, "pperic1@hotmail.com")
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
