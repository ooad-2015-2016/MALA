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
using ZabavniPark.ZabavniPark.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZabavniPark
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AtrakcijaUnos : Page
    {
        private int trajanjeVoznje, brojPosjetilaca;
        public AtrakcijaUnos()
        {
            this.InitializeComponent();
            DataContext = new AtrakcijaViewModel();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxNaziv.Text == "" || textBoxKapacitet.Text == "" || textBoxBrojPosjetilaca.Text == "" || textBoxTrajanjeVoznje.Text == "")
            {
                var dialog = new MessageDialog("Uneseni podaci nisu potpuni", "Neuspješna prijava");
            }

            else if ((!int.TryParse(textBoxTrajanjeVoznje.Text, out trajanjeVoznje)) || (!int.TryParse(textBoxBrojPosjetilaca.Text, out brojPosjetilaca)))
            {
                var dialog = new MessageDialog("Numerički podaci nisu validni", "Neuspješna prijava");
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
