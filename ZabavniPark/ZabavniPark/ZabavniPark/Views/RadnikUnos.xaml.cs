using MyApp_OOAD.ParkBaza.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace ZabavniPark.ZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RadnikUnos : Page
    {
        private String ime;
        private String prezime;
        private double plata;
        private int brojStaza;

        public RadnikUnos()
        {
            this.InitializeComponent();
            List<string> dataList = new List<string>();
            dataList.Add("Radnik na terenu");
            dataList.Add("Radnik na šalteru");
            dataList.Add("Administrator");
        
            listViewTip.ItemsSource = dataList;
        }

         public async void button_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxIme.Text == "" || textBoxPrezime.Text == "" || textBoxPlata.Text == "" || textBoxStaz.Text == "" || textBoxUsername.Text == "")
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
