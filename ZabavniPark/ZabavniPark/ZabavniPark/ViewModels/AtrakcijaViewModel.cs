using MyApp_OOAD.AtrakcijaBaza.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZabavniPark.ZabavniPark.Helper;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class AtrakcijaViewModel
    {
        private static int counter = 0;
        public Atrakcija Atrakcija { get; set; }
        public int AtrakcijaId { get; set; } //primary key u bazi
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public TimeSpan VrijemeOtvaranja { get; set; }
        public TimeSpan VrijemeZatvaranja { get; set; }
        public int TrenutniBrojPosjetilaca { get; set; }
        public StanjeAtrakcije Stanje { get; set; }
        public int TrajanjeVoznje { get; set; }
        public ICommand Dodaj { get; set; }

        public INavigacija NavigationServis { get; set; }

        ObservableCollection<Atrakcija> atrakcije = new ObservableCollection<Atrakcija>();


        public AtrakcijaViewModel()
        {
            //Atrakcija = new Atrakcija();
            NavigationServis = new NavigationService();
            using (var db = new ZabavniParkDbContext())
            {
                 db.Atrakcije.ToList().ForEach(atrakcije.Add);

                Dodaj = new RelayCommand<object>(unosAtrakcije);
                db.Atrakcije.Add(Atrakcija);
            }
        }

        private void unosAtrakcije(object obj)
        {
            AtrakcijaId = System.Threading.Interlocked.Increment(ref counter);
            Atrakcija = new Atrakcija(AtrakcijaId, Naziv, Kapacitet, VrijemeOtvaranja, VrijemeZatvaranja, TrenutniBrojPosjetilaca, Stanje, TrajanjeVoznje);
            // ovdje mozda dodati neki dijalog da obavijesti radnika da je uspjesno unijeta atrakcija
        }
    }
}
