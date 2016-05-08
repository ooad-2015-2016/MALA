using System;
using System.Collections.Generic;
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
using ZabavniPark.ZabavniPark.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZabavniPark.ZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaPosjetilac : Page
    {
        public RegistracijaPosjetilac()
        {
            this.InitializeComponent();
            DataContext = new RegistracijaPosjetilacViewModel();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if((textBox.Text == "") || (textBox1.Text == "") || (passwordBox.Password != passwordBox1.Password) || (datumRodjenjaPicker.Date > DateTime.Today))
            {
                var dialog = new MessageDialog("Uneseni podaci su netačni ili nepotpuni!", "Neuspješna registracija");

                await dialog.ShowAsync();
            }
        }
    }
}
