using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
    public class Atrakcija
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtrakcijaId { get; set; } //primary key u bazi
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public TimeSpan VrijemeOtvaranja { get; set; }
        public TimeSpan VrijemeZatvaranja { get; set; }
        public int TrenutniBrojPosjetilaca { get; set; }
        public StanjeAtrakcije Stanje { get; set; }
        public int TrajanjeVoznje { get; set; } // u minutama
        public Coordinates koordinate { get; set; }

        public Atrakcija(int id, string naziv,
                        int kapacitet, TimeSpan otvaranje,
                         TimeSpan zatvaranje, int trenutniBrPosjetilaca,
                         StanjeAtrakcije stanje, int trajanje, Coordinates koordinate_)
        {
            AtrakcijaId = id;
            Naziv = naziv;
            Kapacitet = kapacitet;
            VrijemeOtvaranja = otvaranje;
            VrijemeZatvaranja = zatvaranje;
            TrenutniBrojPosjetilaca = trenutniBrPosjetilaca;
            Stanje = stanje;
            TrajanjeVoznje = trajanje;
            koordinate = koordinate_;
        }

        public Atrakcija(Atrakcija a)
        {
            this.AtrakcijaId = AtrakcijaId;
            Naziv = a.Naziv;
            Kapacitet = a.Kapacitet;
            VrijemeOtvaranja = a.VrijemeOtvaranja;
            VrijemeZatvaranja = a.VrijemeZatvaranja;
            TrenutniBrojPosjetilaca = a.TrenutniBrojPosjetilaca;
            Stanje = a.Stanje;
            TrajanjeVoznje = a.TrajanjeVoznje;
            koordinate = a.koordinate;
        }
        public Atrakcija() { }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
