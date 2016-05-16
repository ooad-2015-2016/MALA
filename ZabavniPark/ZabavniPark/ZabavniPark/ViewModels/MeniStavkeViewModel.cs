using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    //ViewModel koji omogućava korištenje Model klase na view za potrebe prikaza menija u ListView
   // kontroli
    public class MeniStavkeViewModel
    {
        private int _meniStavkaId;
        public int MeniStavkaId
        {
            get
            {
                return _meniStavkaId;
            }
        }
        public string Naziv { get; set; }
        public Type Podstranica { get; set; }
        public MeniStavkeViewModel()
        {
        }
        //metoda koja mapira MeniStavke iz Modela u ViewModel koji se koristi na view-u
        public static MeniStavkeViewModel SaMeniStavke(MeniStavka menistavka)
        {
            var viewModel = new MeniStavkeViewModel();
            viewModel._meniStavkaId = menistavka.MeniStavkaId;
            viewModel.Naziv = menistavka.Naziv;
            viewModel.Podstranica = menistavka.Podstranica;
            return viewModel;
        }
    }
}
