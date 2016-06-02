using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class PregledAtrakcijaViewModel : INotifyPropertyChanged
    {
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnNotifyPropertyChanged("Naziv");
            }
        }       

        private string stanje;
        public string Stanje
        {
            get { return stanje; }
            set
            {
                stanje = value;
                OnNotifyPropertyChanged("Stanje");
            }
        }

        private string vrijemeOtvaranja;
        public string VrijemeOtvaranja
        {
            get { return vrijemeOtvaranja; }
            set
            {
                vrijemeOtvaranja = value;
                OnNotifyPropertyChanged("Otvaranje");
            }
        }

        private string vrijemeZatvaranja;
        public string VrijemeZatvaranja
        {
            get { return vrijemeZatvaranja; }
            set
            {
                vrijemeZatvaranja = value;
                OnNotifyPropertyChanged("Zatvaranje");
            }
        }

        private string vrijemeCekanja;        
        public string VrijemeCekanja
        {
            get { return vrijemeCekanja; }
            set
            {
                vrijemeCekanja = value;
                OnNotifyPropertyChanged("Cekanje");
            }
        }

        public PregledAtrakcijaViewModel(Atrakcija a)
        {
            nadjiAtrakciju(a);
        }

        public void nadjiAtrakciju(Atrakcija a)
        {
            Naziv = a.Naziv;
            VrijemeOtvaranja = a.VrijemeOtvaranja.ToString();
            VrijemeZatvaranja = a.VrijemeZatvaranja.ToString();

            if (DateTime.Now.TimeOfDay < a.VrijemeOtvaranja || DateTime.Now.TimeOfDay > a.VrijemeZatvaranja)
            {
                Stanje = "ZATVORENO";
            }
            else
            {
                if (a.Stanje == (StanjeAtrakcije)1)
                    Stanje = "OTVORENO";
                else
                    Stanje = "U KVARU";
            }

            int vrijeme = (int)((a.TrajanjeVoznje + 3) * ((a.TrenutniBrojPosjetilaca + 1) / a.Kapacitet) + 0.5);
            VrijemeCekanja = vrijeme.ToString() + " minuta";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
