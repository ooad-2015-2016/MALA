using NoviProjekatZabavniPark.Helper;
using NoviProjekatZabavniPark.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using System;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class RadnikUnosViewModel : INotifyPropertyChanged
    {
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

        #region Privatni atributi
        private static int counter = 0;
        private int radnikID;
        private string ime;
        private string prezime;
        private TipOsoblja tip;
        string username;
        string password;
        string staz;
        string plata;
        #endregion

        #region Postavljanje Property-a
        public int IDRadnika
        {
            get { return radnikID; }
            set { radnikID = value; }
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
        public TipOsoblja TipRadnika
        {
            get { return tip; }
            set
            {
                tip = value;
                NotifyPropertyChanged("TipRadnika");
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
        public string RadniStaz
        {
            get { return staz; }
            set
            {
                staz = value;
                NotifyPropertyChanged("RadniStaz");
            }
        }
        public string Plata
        {
            get { return plata; }
            set
            {
                plata = value;
                NotifyPropertyChanged("Plata");
            }
        }
        #endregion

        public ICommand Dodaj { get; set; }
        public Radnik Radnik { get; set; }

        public RadnikUnosViewModel()
        {
            Dodaj = new RelayCommand<object>(unosRadnika);
        }

        private async void unosRadnika(object obj)
        {
            using (var db = new ZabavniParkDbContext())
            {
                var uneseniRadnik = new Radnik(Ime, Prezime, TipOsoblja.RadnikSalter, Username, Password, Convert.ToInt32(RadniStaz), Convert.ToDouble(Plata));
                db.Radnici.Add(uneseniRadnik);
                db.SaveChanges();

                var message = new MessageDialog("Uspješno je unesen novi radnik", "Unos radnika");
                await message.ShowAsync();

                Ime = string.Empty;
                Prezime = string.Empty;
                Username = string.Empty;
                Password = string.Empty; 
                RadniStaz = string.Empty;
                Plata = string.Empty;
            }
        }
    }
}
