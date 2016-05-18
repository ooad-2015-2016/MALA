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
using ZabavniPark.DataSource;
using ZabavniPark.ZabavniPark.Models;
using ZabavniPark.ZabavniPark.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZabavniPark.ZabavniPark.Views
{

    public sealed partial class Login : Page
    {

        public Login()
        {
            this.InitializeComponent();
            DataContext = new LoginViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            //DataContext = (LoginViewModel)e.Parameter;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            //string username = textBoxUsername.Text;
            //string sifra = passwordBox.Password;
            //this.Frame.Navigate(typeof(PocetnaAdmin), sender);
        }

    }
}
