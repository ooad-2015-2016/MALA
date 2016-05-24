using OOADZabavniPark.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OOADZabavniPark.Views
{
    public sealed partial class RadnikUnos : Page
    {
        double plata; int brojStaza;

        public RadnikUnos()
        {
            this.InitializeComponent();
            DataContext = new RadnikUnosViewModel();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;

        }

        public async void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text == "" || textBoxPrezime.Text == "" || textBoxPlata.Text == "" || textBoxStaz.Text == "" || textBoxUsername.Text == "")
            {
                var dialog = new MessageDialog("Podaci nisu potpuni!", "Neuspješna prijava");
                await dialog.ShowAsync();
            }
            else if ((!Double.TryParse(textBoxPlata.Text, out plata)) || !(int.TryParse(textBoxStaz.Text, out brojStaza)))
            {
                var dialog = new MessageDialog("Numerička polja nisu validna!", "Neuspješna prijava");
                await dialog.ShowAsync();
            }
        }


        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
