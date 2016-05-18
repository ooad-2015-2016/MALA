using MyApp_OOAD.ParkBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using ZabavniPark.ZabavniPark.DataSource;
using ZabavniPark.ZabavniPark.Helper;
using ZabavniPark.ZabavniPark.Models;
using ZabavniPark.ZabavniPark.Views;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Korisnik Radnik { get; set; }

        public ICommand LoginRadnik { get; set; }
        //public ICommand LoginAdmin { get; set; }

        public INavigacija NavigationServis { get; set; }
        
        public LoginViewModel()
        {
            NavigationServis = new NavigationService();
            LoginRadnik = new RelayCommand<object>(loginRadnik, mozeLiSePrijavitiRadnik);
            //LoginAdmin = new RelayCommand<object>(loginAdmin, mozeLiSePrijavitiAdmin);
        }

        private async void loginRadnik(object obj)
        {
            using (var db = new ZabavniParkDbContext())
            {
                Radnik = DataSourcePark.ProvjeraKorisnika(Username, Password);

                if(Radnik == null)
                {
                    var message = new MessageDialog("Podaci nisu tačni!", "Neuspješna prijava");
                    await message.ShowAsync();
                }
                else
                {
                    if(Radnik.KorisnickoIme == "admin") { NavigationServis.Navigate(typeof(PocetnaAdmin)); } 
                    else { NavigationServis.Navigate(typeof(PocetnaRadnik)); }
                }
            }
        }

        //private bool mozeLiSePrijavitiAdmin(object arg)
        //{
        //    return true;
        //}

        private bool mozeLiSePrijavitiRadnik(object arg)
        {
            return true;
        }

    }
}
