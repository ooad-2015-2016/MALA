using NoviProjekatZabavniPark.Helper;
using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class PosjetilacRegistracijaViewModel : INotifyPropertyChanged
    {
        private static int counter = 0;

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        #region Privatni atributi
        private int id;
        private string ime;
        private string prezime;
        private string username;
        private string password;
        private string password2;
        private DateTime datumRodjenja;
        private string email;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                NotifyPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                NotifyPropertyChanged("Prezime");
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                datumRodjenja = value;
                NotifyPropertyChanged("DatumRodjenja");
            }
        }
        public string EMail
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("EMail");
            }
        }
        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = value;
                NotifyPropertyChanged("Password2");
            }
        }
        #endregion

        public ICommand Dodaj { get; set; }
        public Posjetilac Posjetilac { get; set; }

        public PosjetilacRegistracijaViewModel()
        {
            Dodaj = new RelayCommand<object>(unosPosjetioca);
        }

        private async void unosPosjetioca(object obj)
        {
            if (Ime == null || Prezime == null || EMail == null || Password == null || Password2 == null)
            {
                var poruka = new MessageDialog("Uneseni podaci nisu potpuni", "Greška!");
                await poruka.ShowAsync();
            }

            if (Password != Password2)
            {
                var poruka = new MessageDialog("Unesene šifre se ne podudaraju", "Greška!");
                await poruka.ShowAsync();
            }
            if ((((DateTime.Today - DatumRodjenja).TotalDays) / 365) < 13)
            {
                var poruka = new MessageDialog("Morate biti stariji od 13 godina da bi se registrovali na MALA sistem!", "Greška!");
                await poruka.ShowAsync();
            }



            else
            {
                ID = System.Threading.Interlocked.Increment(ref counter);

                Posjetilac = new Posjetilac(ID, Ime, Prezime, DatumRodjenja, Username, Password, EMail, new List<Karta>());

                // ovdje ide kod koji dodaje novog posjetioca u bazu
                //using (var db = new ZabavniParkDbContext())
                //{


                var dialog = new MessageDialog("Uspješno ste registrovani na MALA sistem!", "Registracija na MALA sistem");
                await dialog.ShowAsync();

                //}

                Ime = string.Empty;
                Prezime = string.Empty;
                Username = string.Empty;
                Password = string.Empty;
                Password2 = string.Empty;
                DatumRodjenja = DateTime.Today;
                EMail = string.Empty;
            }
        }
    }
}
