using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZabavniPark.DataSource;
using ZabavniPark.ZabavniPark.Models;
using ZabavniPark.ZabavniPark.ViewModels;
using ZabavniPark.ZabavniPark.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZabavniPark
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {

        public Login()
        {
            this.InitializeComponent();
            DataContext = new PrijavaRegistracijaViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        //Sluzi da kad se dodje na ovu formu, treba onemoguciti back dugme jer se nema gdje vratiti
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PocetnaAdmin), sender);
            //var korisnickoIme = txtUsername.Text;
            //var sifra = txtPassword.Password;
            //Korisnik korisnik = DataSourceMenuMD.ProvjeraKorisnika(korisnickoIme, sifra);
            //if (korisnik != null && korisnik.KorisnikId > 0)
            //{
            //    this.Frame.Navigate(typeof(RegistracijaPosjetilac), korisnik);
            //}
            //else
            //{
            //    var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");
            //    await dialog.ShowAsync();
            //}
        }
    }
}
