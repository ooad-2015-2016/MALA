using NoviProjekatZabavniPark.Models;
using NoviProjekatZabavniPark.ViewModels;
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
    public sealed partial class PregledMape : Page
    {
        private List<Atrakcija> SveAtrakcije;

        public PregledMape()
        {
            this.InitializeComponent();
            using (var context = new ZabavniParkDbContext())
            {
                SveAtrakcije = context.Atrakcije.ToList<Atrakcija>();
            }
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {           
            base.OnNavigatedTo(e);
            DataContext = new PregledMapeViewModel();
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
            e.Handled = true;
        }

        private void textBlock_Copy6_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_evertwon_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[6]);
        }

        private void button_playRealm_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[7]);
        }

        private void button_ghostParadise_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[5]);
        }

        private void button_shockland_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[4]);
        }

        private void button_fundDome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[2]);
        }

        private void button_phantomtown_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[3]);
        }

        private void button_cryptzone_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[0]);
        }

        private void button_dreamville_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PregledAtrakcija), SveAtrakcije[1]);
        }
    }
}
