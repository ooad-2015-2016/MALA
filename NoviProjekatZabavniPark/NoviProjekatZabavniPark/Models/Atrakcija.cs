using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.Models
{
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Atrakcija(string naziv,
                        int kapacitet, TimeSpan otvaranje,
                         TimeSpan zatvaranje, int trenutniBrPosjetilaca,
                         StanjeAtrakcije stanje, int trajanje,
                         double latitude, double longitude)
        {
            Naziv = naziv;
            Kapacitet = kapacitet;
            VrijemeOtvaranja = otvaranje;
            VrijemeZatvaranja = zatvaranje;
            TrenutniBrojPosjetilaca = trenutniBrPosjetilaca;
            Stanje = stanje;
            TrajanjeVoznje = trajanje;
            Latitude = latitude;
            Longitude = longitude;
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
            Latitude = a.Latitude;
            Longitude = a.Longitude;
        }
        public Atrakcija() { }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
