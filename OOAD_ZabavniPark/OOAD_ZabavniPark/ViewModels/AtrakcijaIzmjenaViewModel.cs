using OOAD_ZabavniPark.Helper;
using OOAD_ZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace OOAD_ZabavniPark.ViewModels
{
    public class AtrakcijaIzmjenaViewModel
    {
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public TimeSpan VrijemeOtvaranja { get; set; }
        public TimeSpan VrijemeZatvaranja { get; set; }
        public int TrenutniBrojPosjetilaca { get; set; }
        public StanjeAtrakcije Stanje { get; set; }
        public int TrajanjeVoznje { get; set; } // u minutama

        public string KliknutaAtrakcijaIme { get; set; }
        public Atrakcija KliknutaAtrakcija { get; set; }
        public ICommand Spasi { get; set; }
        public ICommand KlikNaListu { get; set; }
        public List<Atrakcija> Atrakcije
        {
            get { return Atrakcije; }
            set
            {
                Atrakcije = new List<Atrakcija>()
                {
                new Atrakcija(0, "Rollercoaster", 100, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0, StanjeAtrakcije.Operating, 10),
                new Atrakcija(1, "Tobogan", 50, new TimeSpan(8, 0, 0), new TimeSpan(23, 0, 0), 0, StanjeAtrakcije.Operating, 10)
                };
            }
        }


        public AtrakcijaIzmjenaViewModel()
        {
            Spasi = new RelayCommand<object>(spasiAtrakciju);
            KlikNaListu = new RelayCommand<object>(klikNaListu);
            KliknutaAtrakcija = new Atrakcija();
        }

        private void klikNaListu(object obj)
        {
            KliknutaAtrakcija = Atrakcije.Find(a => a.Naziv == KliknutaAtrakcijaIme);
            Naziv = KliknutaAtrakcija.Naziv;
            Kapacitet = KliknutaAtrakcija.Kapacitet;
            VrijemeOtvaranja = KliknutaAtrakcija.VrijemeOtvaranja;
            VrijemeZatvaranja = KliknutaAtrakcija.VrijemeZatvaranja;
            Stanje = KliknutaAtrakcija.Stanje;
            TrenutniBrojPosjetilaca = KliknutaAtrakcija.TrenutniBrojPosjetilaca;
            TrajanjeVoznje = KliknutaAtrakcija.TrajanjeVoznje;
        }

        private async void spasiAtrakciju(object obj)
        {
            //Ovdje ide kod koji spašava u bazu podataka

            // Za test, može samo spašavanje u listu koja je napravljena na početku klase

            var message = new MessageDialog("Radi", "Radi");
            await message.ShowAsync();
        }
    }
}
