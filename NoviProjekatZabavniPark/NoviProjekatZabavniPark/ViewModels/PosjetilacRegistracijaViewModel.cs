﻿using NoviProjekatZabavniPark.Helper;
using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class PosjetilacRegistracijaViewModel : INotifyPropertyChanged
    {

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
        private string ime;
        private string prezime;
        private string username;
        private string password;
        private string password2;
        private DateTime datumRodjenja;
        private string email;
        #endregion

        #region Properties
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
        public ICommand Uslikaj { get; set; }
        public Posjetilac Posjetilac { get; set; }
        public CameraHelper Camera { get; set; }
        //Negdje privremeno mora biti slika koja ce se prikazati kad se uslika
        private SoftwareBitmapSource slika;
        public SoftwareBitmapSource Slika { get { return slika; } set { slika = value; NotifyPropertyChanged("Slika"); } }
        //CaptureElement previewControl;

        public PosjetilacRegistracijaViewModel(CaptureElement previewControl)
        {
            Dodaj = new RelayCommand<object>(unosPosjetioca);
            Uslikaj = new RelayCommand<object>(uslikaj, (object parametar) => true);
            DatumRodjenja = DateTime.Now;
            Camera = new CameraHelper(previewControl);
            Camera.InitializeCameraAsync();
        }

        private async void uslikaj(object obj)
        {
            await Camera.TakePhotoAsync(SlikanjeGotovo);
        }

        private void SlikanjeGotovo(SoftwareBitmapSource obj)
        {
            Slika = obj;
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

            else
            {
                using (var db = new ZabavniParkDbContext())
                {
                    Posjetilac = new Posjetilac(Ime, Prezime, DatumRodjenja, Username, Password, EMail, new List<Karta>());

                    db.Posjetioci.Add(Posjetilac);
                    db.SaveChanges();


                    var dialog = new MessageDialog("Uspješno ste registrovani na MALA sistem!", "Registracija na MALA sistem");
                    await dialog.ShowAsync();


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
}
