using Microsoft.Data.Entity.ChangeTracking;
using NoviProjekatZabavniPark.Helper;
using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class RadnikIzmjenaViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        #region Privatni atributi
        private string ime;
        private string prezime;
        private string username;
        private string password;
        private string plata;
        private string radniStaz;
        private TipOsoblja tip;
        private ObservableCollection<Radnik> radnici;
        #endregion
        
        #region Postavljanje property-a
        public string Ime
        {
            get { return ime; }
            set
            {
                this.ime = value;
                NotifyPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                this.prezime = value;
                NotifyPropertyChanged("Prezime");
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                this.username = value;
                NotifyPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                this.password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string Plata
        {
            get { return plata; }
            set
            {
                this.plata = value;
                NotifyPropertyChanged("Plata");
            }
        }
        public string RadniStaz
        {
            get { return radniStaz; }
            set
            {
                this.radniStaz = value;
                NotifyPropertyChanged("RadniStaz");
            }
        }
        public TipOsoblja TipRadnika
        {
            get { return tip; }
            set
            {
                this.tip = value;
                NotifyPropertyChanged("TipRadnika");
            }
        }

        public IEnumerable<TipOsoblja> TipoviRadnika
        {
            get
            {
                return Enum.GetValues(typeof(TipOsoblja)).Cast<TipOsoblja>();
            }
        }

        public Radnik KliknutiRadnik { get; set; }
            
        public ObservableCollection<Radnik> Radnici
        {
            get { return radnici; }
            set
            {
                radnici = value;
                NotifyPropertyChanged("Radnici");
            }
        }

        #endregion

        #region ICommands
        public ICommand Spasi { get; set; }
        public ICommand Obrisi { get; set; }
        public ICommand KlikNaListu { get; set; }
        #endregion

        public RadnikIzmjenaViewModel()
        {
            Spasi = new RelayCommand<object>(izmjeniRadnika);
            Obrisi = new RelayCommand<object>(obrisiRadnika);
            KlikNaListu = new RelayCommand<ItemClickEventArgs>(klikNaListu);
            using (var context = new ZabavniParkDbContext())
            {
                Radnici = new ObservableCollection<Radnik>(context.Radnici.ToList<Radnik>());
            }

            //var enum_names = Enum.GetNames(typeof(TipOsoblja));
            //EnumCol = enum_names;
        }

        private void obrisiRadnika(object obj)
        {
            Radnik rad, radLista;
            radLista = Radnici.FirstOrDefault(a => a.KorisnickoIme == KliknutiRadnik.KorisnickoIme);

            using (var context = new ZabavniParkDbContext())
            {
                rad = context.Radnici.Where(a => a.KorisnickoIme == KliknutiRadnik.KorisnickoIme).FirstOrDefault<Radnik>();
                context.Entry(rad).State = Microsoft.Data.Entity.EntityState.Deleted;
                Radnici.Remove(radLista);
                context.SaveChanges();
            }
        }

        private void klikNaListu(ItemClickEventArgs args)
        {
            KliknutiRadnik = args.ClickedItem as Radnik;

            Ime = KliknutiRadnik.Ime;
            Prezime = KliknutiRadnik.Prezime;
            Username = KliknutiRadnik.KorisnickoIme;
            Password = KliknutiRadnik.Sifra;
            RadniStaz = (KliknutiRadnik.RadniStaz).ToString();
            Plata = (KliknutiRadnik.Plata).ToString();
            TipRadnika = KliknutiRadnik.Tip;
        }

        //update radnika
        private async void izmjeniRadnika(object obj)
        {
            // Ovdje ide kod koji spašava u bazu podataka
            Radnik rad, radLista;

            using (var context = new ZabavniParkDbContext())
            {
                rad = context.Radnici.Where(a => a.KorisnickoIme == KliknutiRadnik.KorisnickoIme).FirstOrDefault<Radnik>();
                radLista = Radnici.FirstOrDefault(r => r.KorisnickoIme == KliknutiRadnik.KorisnickoIme);
                Radnici.Remove(radLista);

            }

            if (rad != null)
            {
                rad.Ime = radLista.Ime = Ime;
                rad.Prezime = radLista.Prezime = Prezime;
                rad.KorisnickoIme = radLista.KorisnickoIme = Username;
                rad.Sifra = radLista.Sifra = Password;
                rad.RadniStaz = radLista.RadniStaz = Convert.ToInt32(RadniStaz);
                rad.Plata = radLista.Plata = Convert.ToDouble(Plata);
                rad.Tip = radLista.Tip = TipRadnika;

                using (var context = new ZabavniParkDbContext())
                {
                    //Mark entity as modified
                    //EntityEntry<Radnik> r = context.Entry(rad);
                    context.Entry(rad).State = Microsoft.Data.Entity.EntityState.Modified;
                    Radnici.Add(radLista);
                    context.SaveChanges();
                }

                var message = new MessageDialog("Radnik je uspješno izmijenjen!", "Izmjena radnika");
                await message.ShowAsync();

                Ime = string.Empty;
                Prezime = string.Empty; ;
                Username = string.Empty;
                Password = string.Empty;
                Plata = string.Empty; 
                RadniStaz = string.Empty;
                //EnumCol = string.Empty;
            }
        }
    }
}
