using OOADZabavniPark.Helper;
using OOADZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace OOADZabavniPark.ViewModels
{
    public class AtrakcijaUnosViewModel : INotifyPropertyChanged
    {
        private static int counter = 0;

        #region Privatni Atributi
        string naziv;
        int kapacitet;
        TimeSpan vrijemeOtvaranja;
        TimeSpan vrijemeZatvaranja;
        StanjeAtrakcije stanje;
        int brPosjetilaca;
        int trajanjeVoznje;
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

        public Atrakcija Atrakcija { get; set; }
        public int AtrakcijaId { get; set; } //primary key u bazi

        public ICommand Dodaj { get; set; }

        public INavigacija NavigationServis { get; set; }

        ObservableCollection<Atrakcija> atrakcije = new ObservableCollection<Atrakcija>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public AtrakcijaUnosViewModel()
        {
            //Atrakcija = new Atrakcija();
            NavigationServis = new NavigationService();
            Dodaj = new RelayCommand<object>(unosAtrakcije);
        }

        private async void unosAtrakcije(object obj)
        {
            // ovdje ide kod koji vrši spašavanje nove atrakcije u bazu podataka
            AtrakcijaId = System.Threading.Interlocked.Increment(ref counter);
            Atrakcija = new Atrakcija(AtrakcijaId, Naziv, Kapacitet, VrijemeOtvaranja, VrijemeZatvaranja, TrenutniBrojPosjetilaca, Stanje, TrajanjeVoznje);
            using (var db = new ZabavniParkDbContext())
            {
                db.Atrakcije.ToList().ForEach(atrakcije.Add);

                db.Atrakcije.Add(Atrakcija);
            }
            var message = new MessageDialog("Uspješno je unesena nova atrakcija!", "Unos atrakcije");
            await message.ShowAsync();

        }
    }
}
