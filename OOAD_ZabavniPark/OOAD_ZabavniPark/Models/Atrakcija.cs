﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADZabavniPark.Models
{
    public enum StanjeAtrakcije { Operating, NotOperating };
    public class Atrakcija 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } //primary key u bazi
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
            ID = id;
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
            this.ID = ID;
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
