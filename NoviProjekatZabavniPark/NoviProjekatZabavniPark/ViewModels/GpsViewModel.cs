using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace NoviProjekatZabavniPark.ViewModels
{
    class GpsViewModel : INotifyPropertyChanged
    {
        public Geopoint TrenutnaLokacija { get; set; }
        public string Lokacija { get; set; }
        public string Adresa { get; set; }

        public GpsViewModel() { dajLokaciju(); }

        public async void dajLokaciju()
        {
            Geoposition pos = null;
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 10 };
                pos = await geolocator.GetGeopositionAsync();
            }

            TrenutnaLokacija = pos.Coordinate.Point;
            Lokacija = "Latitude: " + TrenutnaLokacija.Position.Latitude + " Longitude: " + TrenutnaLokacija.Position.Longitude;
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pos.Coordinate.Point);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                Adresa = "Adresa: " + result.Locations[0].Address.Street;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
