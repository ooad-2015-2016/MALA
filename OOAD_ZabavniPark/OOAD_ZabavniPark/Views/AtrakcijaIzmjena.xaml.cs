using OOADZabavniPark.Helper;
using OOADZabavniPark.Models;
using OOADZabavniPark.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OOADZabavniPark.Views
{
    public sealed partial class AtrakcijaIzmjena : Page
    { 
        public AtrakcijaIzmjena()
        {
            this.InitializeComponent();
            DataContext = new AtrakcijaIzmjenaViewModel();
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
    }
}
