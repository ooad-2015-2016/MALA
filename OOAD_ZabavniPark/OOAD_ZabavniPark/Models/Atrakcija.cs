using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_ZabavniPark.Models
{
    public enum StanjeAtrakcije { Operating, NotOperating };
    public class Atrakcija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtrakcijaId { get; set; } //primary key u bazi
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public TimeSpan VrijemeOtvaranja { get; set; }
        public TimeSpan VrijemeZatvaranja { get; set; }
        public int TrenutniBrojPosjetilaca { get; set; }
        public StanjeAtrakcije Stanje { get; set; }
        public int TrajanjeVoznje { get; set; } // u minutama

        public Atrakcija(int id, string naziv,
                        int kapacitet, TimeSpan otvaranje,
                         TimeSpan zatvaranje, int trenutniBrPosjetilaca,
                         StanjeAtrakcije stanje, int trajanje)
        {
            AtrakcijaId = id;
            Naziv = naziv;
            Kapacitet = kapacitet;
            VrijemeOtvaranja = otvaranje;
            VrijemeZatvaranja = zatvaranje;
            TrenutniBrojPosjetilaca = trenutniBrPosjetilaca;
            Stanje = stanje;
            TrajanjeVoznje = trajanje;
        }
        public Atrakcija(Atrakcija a)
        {
            Naziv = a.Naziv;
            Kapacitet = a.Kapacitet;
            VrijemeOtvaranja = a.VrijemeOtvaranja;
            VrijemeZatvaranja = a.VrijemeZatvaranja;
            TrenutniBrojPosjetilaca = a.TrenutniBrojPosjetilaca;
            Stanje = a.Stanje;
            TrajanjeVoznje = a.TrajanjeVoznje;
        }
        public Atrakcija() { }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
