using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public enum TipPosjetilaca { Obicni, Registrovani, Gold }
    public class Posjetilac
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PosjetilacId { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int ClanskiBroj { get; set; }
        public TipPosjetilaca Tip { get; set; }
        public String Sifra { get; set; }

        public Posjetilac(int id, String ime, String prezime, DateTime datum, int clanskiBroj, TipPosjetilaca tip, String sifra)
        {
            PosjetilacId = id;
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datum;
            ClanskiBroj = clanskiBroj;
            Tip = tip;
            Sifra = sifra;
        }

        public Posjetilac() { }
    }
}
