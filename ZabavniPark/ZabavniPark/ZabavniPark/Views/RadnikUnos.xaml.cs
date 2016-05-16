using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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


    }
}
