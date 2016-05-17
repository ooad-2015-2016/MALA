using MyApp_OOAD.ParkBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using ZabavniPark.ZabavniPark.Helper;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class RadnikViewModel
    {
        private static int counter = 0;
        public Radnik Radnik { get; set; }
        public int IDRadnika { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public TipOsoblja TipRadnika { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int RadniStaz { get; set; }
        public double Plata { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand Unos { get; set; }

        public RadnikViewModel()
        {
            NavigationServis = new NavigationService();
            Unos = new RelayCommand<object>(unosRadnika);
        }

        private void unosRadnika(object obj)
        {
            IDRadnika = System.Threading.Interlocked.Increment(ref counter);
            Radnik = new Radnik(IDRadnika, Ime, Prezime, TipRadnika, Username, Password, RadniStaz, Plata);
            //var dialog = new MessageDialog("Uspješno je unesen novi radnik", "Unos radnika");
        }
    }
}
