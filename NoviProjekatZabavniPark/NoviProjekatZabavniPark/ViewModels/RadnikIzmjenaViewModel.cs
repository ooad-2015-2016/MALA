using NoviProjekatZabavniPark.Helper;
using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class RadnikIzmjenaViewModel : INotifyPropertyChanged
    {
        #region Privatni atributi
        private string ime;
        private string prezime;
        private string username;
        private string password;
        private string plata;
        private string radniStaz;
        private TipOsoblja tip;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
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

        public Radnik KliknutiRadnik { get; set; }
        #endregion

        public ICommand Spasi { get; set; }
        public ICommand KlikNaListu { get; set; }



        public RadnikIzmjenaViewModel()
        {
            Spasi = new RelayCommand<object>(izmjeniRadnika);
            KlikNaListu = new RelayCommand<ItemClickEventArgs>(klikNaListu);
        }

        //update radnika
        private void klikNaListu(ItemClickEventArgs args)
        {
            KliknutiRadnik = args.ClickedItem as Radnik;
            Radnik rad;

            using (var context = new ZabavniParkDbContext())
            {
                rad = context.Radnici.Where(a => a.KorisnickoIme == KliknutiRadnik.KorisnickoIme).FirstOrDefault<Radnik>();
            }

            if (rad != null)
            {
                rad.Ime = Ime;
                rad.Prezime = Prezime;
                rad.KorisnickoIme = Username;
                rad.Sifra = Password;
                rad.RadniStaz = Convert.ToInt32(RadniStaz);
                rad.Plata = Convert.ToDouble(Plata);
            }
            using (var context = new ZabavniParkDbContext())
            {
                //Mark entity as modified
                context.Entry(rad).State = Microsoft.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }


        private void izmjeniRadnika(object obj)
        {
            // Ovdje ide kod koji spašava u bazu podataka
        }
    }
}
