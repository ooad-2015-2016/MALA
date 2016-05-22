using OOADZabavniPark.Helper;
using OOADZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace OOADZabavniPark.ViewModels
{
    public class RadnikUnosViewModel
    {
        //private Image image;

        private static int counter = 0;
        public Radnik Radnik { get; set; }
        // public Image Slika { get; set; }
        public int IDRadnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public TipOsoblja TipRadnika { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RadniStaz { get; set; }
        public double Plata { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand Dodaj { get; set; }

        ObservableCollection<Radnik> radnici = new ObservableCollection<Radnik>();

        public RadnikUnosViewModel()
        {
            NavigationServis = new NavigationService();
            using (var db = new ZabavniParkDbContext())
            {
                //fill collection with initial data from DbContext
                db.Radnici.ToList().ForEach(radnici.Add);

                Dodaj = new RelayCommand<object>(unosRadnika);
                db.Radnici.Add(Radnik);
            }
        }

        private async void unosRadnika(object obj)
        {
            IDRadnika = System.Threading.Interlocked.Increment(ref counter);
            Radnik = new Radnik(IDRadnika, Ime, Prezime, TipRadnika, Username, Password, RadniStaz, Plata);
            var message = new MessageDialog("Uspješno je unesen novi radnik", "Unos radnika");
            await message.ShowAsync();
        }
    }
}
