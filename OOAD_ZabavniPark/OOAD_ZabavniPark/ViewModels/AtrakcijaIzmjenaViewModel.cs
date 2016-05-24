using OOADZabavniPark.Helper;
using OOADZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace OOADZabavniPark.ViewModels
{
    public class AtrakcijaIzmjenaViewModel : INotifyPropertyChanged
    {
        #region Privatni atributi
        private string naziv;
        private int kapacitet;
        private TimeSpan vrijemeOtvaranja;
        private TimeSpan vrijemeZatvaranja;
        private int brPosjetilaca;
        private StanjeAtrakcije stanje;
        private int trajanjeVoznje;
        #endregion

        #region Postavljanje Property-a
        public string Naziv
        {
            get { return naziv; }
            set
            {
                this.naziv = value;
                NotifyPropertyChanged("Naziv");
            }
        }
        public int Kapacitet
        {
            get { return kapacitet; }
            set
            {
                this.kapacitet = value;
                NotifyPropertyChanged("Kapacitet");
            }
        }
        public TimeSpan VrijemeOtvaranja
        {
            get { return vrijemeOtvaranja; }
            set
            {
                this.vrijemeOtvaranja = value;
                NotifyPropertyChanged("VrijemeOtvaranja");
            }
        }
        public TimeSpan VrijemeZatvaranja
        {
            get { return vrijemeZatvaranja; }
            set
            {
                this.vrijemeZatvaranja = value;
                NotifyPropertyChanged("VrijemeZatvaranja");
            }
        }
        public int TrenutniBrojPosjetilaca
        {
            get { return brPosjetilaca; }
            set
            {
                this.brPosjetilaca = value;
                NotifyPropertyChanged("TrenutniBrojPosjetilaca");
            }
        }
        public StanjeAtrakcije Stanje
        {
            get { return stanje; }
            set
            {
                this.stanje = value;
                NotifyPropertyChanged("Stanje");
            }
        }
        public int TrajanjeVoznje
        {
            get { return trajanjeVoznje; }
            set
            {
                this.trajanjeVoznje = value;
                NotifyPropertyChanged("TrajanjeVoznje");
            }
        }

        #endregion
        

        public string KliknutaAtrakcijaIme { get; set; }
        public List<Atrakcija> Atrakcije { get; set; }
        public Atrakcija KliknutaAtrakcija { get; set; }
        public ICommand Spasi { get; set; }
        public ICommand KlikNaListu { get; set; }

        public AtrakcijaIzmjenaViewModel()
        {
            Atrakcije = new List<Atrakcija>()
            {
                new Atrakcija(0, "Rollercoaster", 100, new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 0, StanjeAtrakcije.Operating, 10),
                new Atrakcija(1, "Tobogan", 50, new TimeSpan(8, 0, 0), new TimeSpan(23, 0, 0), 0, StanjeAtrakcije.Operating, 10)
            };
            //KliknutaAtrakcija = new Atrakcija();
            Spasi = new RelayCommand<object>(spasiAtrakciju);
            KlikNaListu = new RelayCommand<ItemClickEventArgs>(klikNaListu);
        }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        private void klikNaListu(ItemClickEventArgs args)
        {
            // TODO: Postaviti SelectedItem ComboBox-a na KliknutaAtrakcija.Stanje

            KliknutaAtrakcija = args.ClickedItem as Atrakcija;
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
