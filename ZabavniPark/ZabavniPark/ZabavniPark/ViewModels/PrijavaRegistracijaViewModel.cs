using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZabavniPark.ZabavniPark.Helper;
using ZabavniPark.ZabavniPark.Views;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class PrijavaRegistracijaViewModel
    {
        public ICommand Registracija { get; set; }
        public INavigacija NavigationServis { get; set; }


        public PrijavaRegistracijaViewModel()
        {
            NavigationServis = new NavigationService();
            // prva metoda je ona koja se pozove na klik, a druga je ona koja testira treba li se pozvati komanda
            Registracija = new RelayCommand<object>(registracija, mozeLiSeRegistrovati);
        }

        public void registracija(object obj)
        {
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view
            //(this) kao Parent

            NavigationServis.Navigate(typeof(RegistracijaPosjetilac), new RegistracijaPosjetilacViewModel());
        }

        public bool mozeLiSeRegistrovati(object arg)
        {
            return true;
        }

        //private async void btnLogin_Click(object sender, RoutedEventArgs e)
        //{

        //    var korisnickoIme = txtUsername.Text;
        //    var sifra = txtPassword.Password;
        //    Korisnik korisnik = DataSourceMenuMD.ProvjeraKorisnika(korisnickoIme, sifra);
        //    if (korisnik != null && korisnik.KorisnikId > 0)
        //    {
        //        this.Frame.Navigate(typeof(MainPage), korisnik);
        //    }
        //    else
        //    {
        //        var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješnaprijava");

        //        await dialog.ShowAsync();
        //    }
        //}
    }
}
