using NoviProjekatZabavniPark.Models;
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
    class PregledMapeViewModel : INotifyPropertyChanged
    {
        #region Atributi
        private Geopoint trenutnaLokacija;
        public Geopoint TrenutnaLokacija
        {
            get { return trenutnaLokacija; }
            set
            {
                trenutnaLokacija = value;
                OnNotifyPropertyChanged("TrenutnaLokacija");
            }
        }

        private string latitude;
        public string Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnNotifyPropertyChanged("Latitude");
            }
        }

        private string longitude;
        public string Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnNotifyPropertyChanged("Longitude");
            }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnNotifyPropertyChanged("Adresa");
            }
        }

        private string cryptzone;
        public string Cryptzone
        {
            get { return cryptzone; }
            set
            {
                cryptzone = value;
                OnNotifyPropertyChanged("Cryptzone");
            }
        }

        private string dreamville;
        public string Dreamville
        {
            get { return dreamville; }
            set
            {
                dreamville = value;
                OnNotifyPropertyChanged("Dreamville");
            }
        }

        private string fundome;
        public string FunDome
        {
            get { return fundome; }
            set
            {
                fundome = value;
                OnNotifyPropertyChanged("FunDome");
            }
        }

        private string phantomtown;
        public string Phantomtown
        {
            get { return phantomtown; }
            set
            {
                phantomtown = value;
                OnNotifyPropertyChanged("Phantomtown");
            }
        }

        private string shockland;
        public string Shockland
        {
            get { return shockland; }
            set
            {
                shockland = value;
                OnNotifyPropertyChanged("Shockland");
            }
        }

        private string ghostparadise;
        public string GhostParadise
        {
            get { return ghostparadise; }
            set
            {
                ghostparadise = value;
                OnNotifyPropertyChanged("GhostParadise");
            }
        }

        private string evertown;
        public string Evertown
        {
            get { return evertown; }
            set
            {
                evertown = value;
                OnNotifyPropertyChanged("Evertown");
            }
        }

        private string playrealm;
        public string PlayRealm
        {
            get { return playrealm; }
            set
            {
                playrealm = value;
                OnNotifyPropertyChanged("PlayRealm");
            }
        }

        private List<Atrakcija> sveAtrakcije;
        public List<Atrakcija> SveAtrakcije
        {
            get { return sveAtrakcije; }
            set
            {
                sveAtrakcije = value;
            }
        }
        #endregion

        public PregledMapeViewModel()
        {
            //SveAtrakcije = new List<Atrakcija>();
            using (var context = new ZabavniParkDbContext())
            {
                SveAtrakcije = context.Atrakcije.ToList<Atrakcija>();
            }
            dajLokaciju();
        }

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
            Latitude = (TrenutnaLokacija.Position.Latitude).ToString(); 
            Longitude = (TrenutnaLokacija.Position.Longitude).ToString();
            
            MapLocationFinderResult result = await
            MapLocationFinder.FindLocationsAtAsync(pos.Coordinate.Point);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                Adresa = result.Locations[0].Address.Street;
            }

            Cryptzone = (GetDistanceInKm(SveAtrakcije[0].Latitude, SveAtrakcije[0].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            Dreamville = (GetDistanceInKm(SveAtrakcije[1].Latitude, SveAtrakcije[1].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            FunDome = (GetDistanceInKm(SveAtrakcije[2].Latitude, SveAtrakcije[2].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            Phantomtown = (GetDistanceInKm(SveAtrakcije[3].Latitude, SveAtrakcije[3].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            Shockland = (GetDistanceInKm(SveAtrakcije[4].Latitude, SveAtrakcije[4].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            GhostParadise = (GetDistanceInKm(SveAtrakcije[5].Latitude, SveAtrakcije[5].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            Evertown = (GetDistanceInKm(SveAtrakcije[6].Latitude, SveAtrakcije[6].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
            PlayRealm = (GetDistanceInKm(SveAtrakcije[7].Latitude, SveAtrakcije[7].Longitude, Convert.ToDouble(Latitude), Convert.ToDouble(Longitude))).ToString();
        }

        double GetDistanceInKm(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371d;
            var dLat = Deg2Rad(lat2 - lat1);  
            var dLon = Deg2Rad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2d) * Math.Sin(dLat / 2d) +
              Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) *
              Math.Sin(dLon / 2d) * Math.Sin(dLon / 2d);
            var c = 2d * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1d - a));
            var d = R * c;
            return d;
        }

        double Deg2Rad(double deg)
        {
            return deg * (Math.PI / 180d);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
