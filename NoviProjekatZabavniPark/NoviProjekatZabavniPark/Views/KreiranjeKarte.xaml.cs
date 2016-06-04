using NoviProjekatZabavniPark.ViewModels;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NoviProjekatZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KreiranjeKarte : Page
    {
        public KreiranjeKarte()
        {
            this.InitializeComponent();
            DataContext = new KreiranjeKarteViewModel();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += ThisPage_BackRequested;
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void btnBarcode_Click(object sender, RoutedEventArgs e)
        {
            IBarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 100,
                    Width = 450
                }
            };

            if (comboBox.SelectedIndex == -1)
            {
                var message = new MessageDialog("Tip karte nije odabran!");
                message.ShowAsync();
            }
            else 
            {
                textBox1.Text = DateTime.Now.Date.ToString();
                textBox2.Text = comboBox.SelectedItem.ToString();
                if (comboBox.SelectedIndex == 0)
                {
                    textBox3.Text = "40 KM";
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    textBox3.Text = "30 KM";
                }
                else if (comboBox.SelectedIndex == 2)
                {
                    textBox3.Text = "20 KM";
                }
                else if (comboBox.SelectedIndex == 3)
                {
                    textBox3.Text = "10 KM";
                }
                var result = writer.Write((object)"Datum: " + textBox1.Text + " Tip karte: " + textBox2.Text + " Guest username: guest Password: MALA");
                var wb = result.ToBitmap() as WriteableBitmap;
                imgBarcode.Source = wb;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var message = new MessageDialog("Karta je usješno spremna za izdavanje!");
            message.ShowAsync();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
