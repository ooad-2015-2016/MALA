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
            int cvc;
            if (!int.TryParse(CvcKod, out cvc))
            {
                if (!(cvc <= 100 && cvc < 1000))
                {
                    var messageDialog = new MessageDialog("Nije unesen ispravan CVC Kod!", "Greška pri kupovini karte");
                    await messageDialog.ShowAsync();
                }
            }

            //provjera da li je kartica istekla
            if (DateTime.Compare(DatumIsteka, DateTime.Today) < 0)
            {
                var message = new MessageDialog("Kartica je istekla!", "Greška pri kupovini karte");
                await message.ShowAsync();
            }

            else
            {
                int brojKarata = 0;
                if ((!int.TryParse(BrojKartiDjecijeGold, out brojKarata)) || (!int.TryParse(BrojKartiOdrasliGold, out brojKarata)) || (!int.TryParse(BrojKartiStandardDjecije, out brojKarata)) || (!int.TryParse(BrojKartiStandardOdrasli, out brojKarata)))
                {
                    var messageDialog = new MessageDialog("Uneseni broj karata nije validan!", "Greška");
                }
                else
                {
                    if (int.Parse(BrojKartiDjecijeGold) > 0)
                    {
                        Karta k = new Karta(new DateTime(), TipKarte.GoldDjecija);
                        KupljeneKarte.Add(k);
                    }
                    if (int.Parse(BrojKartiOdrasliGold) > 0)
                    {
                        {
                            Karta k = new Karta(new DateTime(), TipKarte.GoldOdrasli);
                            KupljeneKarte.Add(k);
                        }
                    }
                    if (int.Parse(BrojKartiStandardDjecije) > 0)
                    {
                        {
                            Karta k = new Karta(new DateTime(), TipKarte.StandardDjecija);
                            KupljeneKarte.Add(k);
                        }
                    }
                    if (int.Parse(BrojKartiStandardOdrasli) > 0)
                    {
                        {
                            Karta k = new Karta(new DateTime(), TipKarte.StandardOdrasli);
                            KupljeneKarte.Add(k);
                        }
                    }

                    using (var db = new ZabavniParkDbContext())
                    {
                        ObservableCollection<Posjetilac> Posjetioci = new ObservableCollection<Posjetilac>(db.Posjetioci.ToList<Posjetilac>());

                        //Posjetilac p = Posjetioci.FirstOrDefault(a => a.KorisnickoIme == posjetilac.KorisnickoIme);
                        //p.KupljeneKarte = posjetilac.KupljeneKarte;
                    }
                }

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
