using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KupovinaKarte), p);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            p = e.Parameter as Posjetilac;
            base.OnNavigatedTo(e);
        }

        private void buttonWeather_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VremenskaPrognoza), p);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PregledAtrakcija), p);
        }
    }
}
