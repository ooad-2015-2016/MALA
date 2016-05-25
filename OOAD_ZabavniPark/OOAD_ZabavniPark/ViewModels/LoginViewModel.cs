using OOADZabavniPark.DataSource;
using OOADZabavniPark.Helper;
using OOADZabavniPark.Models;
using OOADZabavniPark.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace OOADZabavniPark.ViewModels
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

        public LoginViewModel()
        {
            NavigationServis = new NavigationService();
            LoginKorisnik = new RelayCommand<object>(loginKorisnik, mozeLiSePrijaviti);
        }

        private async void loginKorisnik(object obj)
        {
            if (Username == "" || Password == "")
            {
                var message = new MessageDialog("Nisu uneseni svi podaci!", "Neuspješna prijava");
                await message.ShowAsync();
            }

            //TODO: Dobavljanje podataka iz baze 

            //using (var db = new ZabavniParkDbContext())
            //{
                Korisnik = DataSourcePark.ProvjeraKorisnika(Username, Password);

                if (Korisnik == null)
                {
                    var message = new MessageDialog("Podaci nisu tačni!", "Neuspješna prijava");
                    await message.ShowAsync();
                }
                else
                {
                    if (Korisnik is Administrator) { NavigationServis.Navigate(typeof(PocetnaAdmin)); }
                    else if(Korisnik is Posjetilac) { NavigationServis.Navigate(typeof(PocetnaPosjetilac), Korisnik); }
                    else { NavigationServis.Navigate(typeof(PocetnaRadnik)); }
                }
            //}
        }

        private bool mozeLiSePrijaviti(object arg)
        {
            return true;
        }

    }
}
