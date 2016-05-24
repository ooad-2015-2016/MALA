using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public enum TipPosjetilaca { Obicni, Registrovani, Gold }

    public class Posjetilac : Korisnik
    {
        #region Properties
        public DateTime DatumRodjenja { get; set; }
        public int BrojKartice { get; set; }
        public TipPosjetilaca Tip { get; set; }
        public string EMail { get; set; }
        #endregion

        #region Konstruktori
        public Posjetilac(int id, string ime, string prezime, DateTime datum, int brojKartice, string username, string password, TipPosjetilaca tip, string email)
            :base(id, username, password, ime, prezime)
        {
            DatumRodjenja = datum;
            BrojKartice = brojKartice;
            Tip = tip;
            EMail = email;
        }

        public Posjetilac(Posjetilac p) : base(p.KorisnikId, p.KorisnickoIme, p.Sifra, p.Ime, p.Prezime)
        {
            DatumRodjenja = p.DatumRodjenja;
            BrojKartice = p.BrojKartice;
            Tip = p.Tip;
            EMail = p.EMail;
        }
        #endregion
    }
}
