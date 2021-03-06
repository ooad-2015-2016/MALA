﻿using NoviProjekatZabavniPark.DataSource;
using NoviProjekatZabavniPark.Helper;
using NoviProjekatZabavniPark.Models;
using NoviProjekatZabavniPark.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Privatni atributi
        private string username;
        private string password;
        #endregion

        #region Properties
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
        #endregion

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

        public Korisnik Korisnik { get; set; }

        public ICommand LoginKorisnik { get; set; }

        public INavigacija NavigationServis { get; set; }

        ObservableCollection<Korisnik> Korisnici { get; set; }

        public LoginViewModel()
        {
            NavigationServis = new NavigationService();
            LoginKorisnik = new RelayCommand<object>(loginKorisnik, mozeLiSePrijaviti);
            using (var db = new ZabavniParkDbContext())
            {
                Korisnici = new ObservableCollection<Korisnik>();

                foreach (Radnik r in db.Radnici)
                    Korisnici.Add(r);
                foreach (Posjetilac p in db.Posjetioci)
                    Korisnici.Add(p);
            }
        }

        private async void loginKorisnik(object obj)
        {
            if (Username == "" || Password == "")
            {
                var message = new MessageDialog("Nisu uneseni svi podaci!", "Neuspješna prijava");
                await message.ShowAsync();
            }
            Korisnik = Korisnici.FirstOrDefault(k => k.KorisnickoIme == Username && k.Sifra == Password);

            if (Korisnik == null && Username != "admin1" && Password != "adminpass")
            {
                var message = new MessageDialog("Podaci nisu tačni!", "Neuspješna prijava");
                await message.ShowAsync();
            }
            else
            {
                if (Username == "admin1" && Password == "adminpass") { NavigationServis.Navigate(typeof(PocetnaAdmin)); }
                else if (Korisnik is Posjetilac) { NavigationServis.Navigate(typeof(PocetnaPosjetilac), Korisnik); }
                else { NavigationServis.Navigate(typeof(PocetnaRadnik)); }
            }
        }

        private bool mozeLiSePrijaviti(object arg)
        {
            return true;
        }

    }
}
