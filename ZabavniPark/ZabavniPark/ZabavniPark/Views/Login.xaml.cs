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
<<<<<<< HEAD
using ZabavniPark.ZabavniPark.ViewModels;
=======
using ZabavniPark.DataSource;
using ZabavniPark.ZabavniPark.Models;
using ZabavniPark.ZabavniPark.ViewModels;
using ZabavniPark.ZabavniPark.Views;
>>>>>>> origin/HEAD

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
<<<<<<< HEAD
            InitializeComponent();
            DataContext = new LoginViewModel();
=======
            this.InitializeComponent();
            DataContext = new PrijavaRegistracijaViewModel();
>>>>>>> origin/HEAD
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            //DataContext = (LoginViewModel)e.Parameter;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            //this.Frame.Navigate(typeof(PocetnaAdmin), sender);
            string username = textBoxUsername.Text;
            string sifra = passwordBox.Password;
=======
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
>>>>>>> origin/HEAD
        }

    }
}
