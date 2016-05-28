using OOADZabavniPark.Models;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OOADZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VremenskaPrognoza : Page
    {
        public VremenskaPrognoza()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(new Coordinates(20.0, 30.0));

            ResultTextBlock.Text = myWeather.name + " - " + myWeather.main.temp + " - " + myWeather.weather[0].description;
            string icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
        }
    }
}
