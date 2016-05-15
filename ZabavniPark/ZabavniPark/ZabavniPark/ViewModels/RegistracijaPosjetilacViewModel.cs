using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZabavniPark.ZabavniPark.Helper;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class RegistracijaPosjetilacViewModel
    {
        private static int counter = 0;
        Posjetilac Posjetilac { get; set; }
        public int IDPosjetioca { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int ClanskiBroj { get; set; }
        public TipPosjetilaca Tip { get; set; }
        public String Sifra { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand Registracija { get; set; }

        public RegistracijaPosjetilacViewModel()
        {
           // Posjetilac = new Posjetilac();
            NavigationServis = new NavigationService();
            Registracija = new RelayCommand<object>(signup);
            
        }

        private void signup(object obj)
        {
            IDPosjetioca = System.Threading.Interlocked.Increment(ref counter);
            Posjetilac = new Posjetilac(IDPosjetioca, Ime, Prezime, DatumRodjenja, ClanskiBroj, Tip, Sifra);
            // ovdje treba dodati da korisnika odvede na neku stranicu(napraviti View) da moze da pregleda atrakcije
            // i eventualno rezervise karte
            //NavigationServis.Navigate(...);
        }
    }
}
