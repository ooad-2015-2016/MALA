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

namespace NoviProjekatZabavniPark.ViewModels
{
    public class KupovinaKarteViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
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
        private string brojKartice;
        private string brojKartiDjecijeGold;
        private string brojKartiOdrasliGold;
        private string brojKartiStandardDjecije;
        private string brojKartiStandardOdrasli;
        private string cvcKod;
        int cvc;
        private DateTime datumIsteka;
        #endregion

        #region Property
        public string BrojKartice
        {
            get { return brojKartice; }
            set
            {
                brojKartice = value;
                NotifyPropertyChanged("BrojKartice");
            }
        }

        public List<Karta> KupljeneKarte { get; set; }
        public string BrojKartiDjecijeGold
        {
            get { return brojKartiDjecijeGold; }
            set
            {
                brojKartiDjecijeGold = value;
                NotifyPropertyChanged("BrojKartiDjecijeGold");
            }
        }
        public string BrojKartiOdrasliGold
        {
            get { return brojKartiOdrasliGold; }
            set
            {
                brojKartiOdrasliGold = value;
                NotifyPropertyChanged("BrojKartiOdrasliGold");
            }
        }
        public string BrojKartiStandardDjecije
        {
            get { return brojKartiStandardDjecije; }
            set
            {
                brojKartiStandardDjecije = value;
                NotifyPropertyChanged("BrojKartiStandardDjecije");
            }
        }
        public string BrojKartiStandardOdrasli
        {
            get { return brojKartiStandardOdrasli; }
            set
            {
                brojKartiStandardOdrasli = value;
                NotifyPropertyChanged("BrojKartiStandardOdrasli");
            }
        }
        public string CvcKod
        {
            get { return cvcKod; }
            set
            {
                cvcKod = value;
                NotifyPropertyChanged("CvcKod");
            }
        }
        public DateTime DatumIsteka
        {
            get { return datumIsteka; }
            set
            {
                datumIsteka = value;
                NotifyPropertyChanged("DatumIsteka");
            }
        }
        public ICommand KupiKartu { get; set; }
        #endregion

        public KupovinaKarteViewModel()
        {
            KupiKartu = new RelayCommand<object>(kupiKartu);
            BrojKartiDjecijeGold = BrojKartiOdrasliGold = BrojKartiStandardDjecije = BrojKartiStandardOdrasli = "0";
            DatumIsteka = DateTime.Today;
        }

        private async void kupiKartu(object obj)
        {
            //provjera da li je unesen broj kartice
            if (BrojKartice == null)
            {
                var messageDialog = new MessageDialog("Nije unesen broj kartice!", "Greška pri kupovini karte");
                await messageDialog.ShowAsync();
            }

            //provjera da li je cvc kod trocifreni cijeli broj
            else if (!int.TryParse(CvcKod, out cvc))
            {
                if (!(cvc <= 100 && cvc < 1000))
                {
                    var messageDialog = new MessageDialog("Nije unesen ispravan CVC Kod!", "Greška pri kupovini karte");
                    await messageDialog.ShowAsync();
                }
            }

            //provjera da li je kartica istekla
            //if (DateTime.Compare(DatumIsteka, DateTime.Today) <= 0)
            //{
            //    var messageDialog = new MessageDialog("Kartica je istekla!", "Greška pri kupovini karte");
            //    await messageDialog.ShowAsync();
            //}

            else
            {
                var message = new MessageDialog("Uspješno ste kupili kartu za Zabavni park MALA!", "Kupovina karte uspješna");
                BrojKartice = string.Empty;
                DatumIsteka = DateTime.Now;
                BrojKartiStandardOdrasli = string.Empty;
                BrojKartiStandardDjecije = string.Empty;
                BrojKartiOdrasliGold = string.Empty;
                BrojKartiDjecijeGold = string.Empty;
                CvcKod = string.Empty;
            }
        }
    }
}
