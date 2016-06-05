using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NoviProjekatZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PocetnaPosjetilac : Page
    {
        Posjetilac p;
        public PocetnaPosjetilac()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
            p = new Posjetilac();
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
                Frame.Navigate(typeof(Login));
                e.Handled = true;
        }

        private void provjeriPosjetioca()
        {
            if (p.KorisnickoIme == "guest") button.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KupovinaKarte));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            p = e.Parameter as Posjetilac;
            provjeriPosjetioca();
        }

        private void buttonWeather_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VremenskaPrognoza));
        }
              
        private void buttonMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PregledMape), p);
        }

        private void buttonKompas_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Kompas));
        }
    }
}
