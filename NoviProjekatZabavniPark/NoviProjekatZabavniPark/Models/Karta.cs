
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NoviProjekatZabavniPark.Models
{
    public class Karta
    {
        //private static int djecijaKarta = 10;
        //private static int odrasliKarta = 20;

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public bool Iskoristena { get; set; }
        public TipKarte Tip { get; set; }
        public Image Kod { get; set; }

        public Karta(DateTime datum, TipKarte tip)
        {
            Datum = datum;
            Iskoristena = false;
            Tip = tip;
        }

        void IskoristiKartu()
        {
            Iskoristena = true;
        }

        void GenerisiKod()
        {
            //Ovdje dodati za pravljenje koda za kartu
        }
    }
}
