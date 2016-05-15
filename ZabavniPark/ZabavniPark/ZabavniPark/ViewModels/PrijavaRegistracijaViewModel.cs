using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZabavniPark.ZabavniPark.Helper;
using ZabavniPark.ZabavniPark.Views;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class PrijavaRegistracijaViewModel
    {
        public ICommand Registracija { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand LoginPosjetilac { get; set; }
        public ICommand LoginRadnik { get; set; }
        // Da li treba i LoginAdmin? - vjerovatno treba, ali nisam sigurna, provjeriti sa asistentom


        public PrijavaRegistracijaViewModel()
        {
            NavigationServis = new NavigationService();
            // prva metoda je ona koja se pozove na klik, a druga je ona koja testira treba li se pozvati komanda
            Registracija = new RelayCommand<object>(registracija, mozeLiSeRegistrovati);
            LoginPosjetilac = new RelayCommand<object>(loginPosjetilac, mozeLiSePrijavitiPosjetilac);
            LoginRadnik = new RelayCommand<object>(loginRadnik, mozeLiSePrijavitiRadnik);
        }

        private bool mozeLiSePrijavitiRadnik(object arg)
        {
            return true;
        }

        private void loginRadnik(object obj)
        {
            // ovdje trebamo napraviti neki RadnikView, tako da omogucimo radnicima promjenu statusa atrakcija i ostale beneficije koje imaju radnici
        }

        private void loginPosjetilac(object obj)
        {
            // ovdje je slucaj kao poslije registracije korisnika, treba da se otvori neki PosjetilacView,
            // gdje posjetilac treba da pregleda atrakcije, rezervise kartu itd.
        }

        private bool mozeLiSePrijavitiPosjetilac(object arg)
        {
            return true;
        }

        public void registracija(object obj)
        {
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view
            //(this) kao Parent

            NavigationServis.Navigate(typeof(RegistracijaPosjetilac), new RegistracijaPosjetilacViewModel());
        }

        public bool mozeLiSeRegistrovati(object arg)
        {
            return true;
        }


    }
}
