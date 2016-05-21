using OOAD_ZabavniPark.DataSource;
using OOAD_ZabavniPark.Helper;
using OOAD_ZabavniPark.Models;
using OOAD_ZabavniPark.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace OOAD_ZabavniPark.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Korisnik Korisnik { get; set; }

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
            if (Username == "" || Password == "")
            {
                var message = new MessageDialog("Nisu uneseni svi podaci!", "Neuspješna prijava");
                await message.ShowAsync();
            }


            using (var db = new ZabavniParkDbContext())
            {
                Korisnik = DataSourcePark.ProvjeraKorisnika(Username, Password);

                if (Korisnik == null)
                {
                    var message = new MessageDialog("Podaci nisu tačni!", "Neuspješna prijava");
                    await message.ShowAsync();
                }
                else
                {
                    if (Korisnik is Administrator) { NavigationServis.Navigate(typeof(PocetnaAdmin)); }
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
