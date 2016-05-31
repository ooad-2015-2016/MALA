using NoviProjekatZabavniPark.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class KreiranjeKarteViewModel
    {
        public ICommand Kreiraj { get; set; }

        public KreiranjeKarteViewModel()
        {
            Kreiraj = new RelayCommand<object>(kreiranjeKarte);
        }

        private void kreiranjeKarte(object obj)
        {
            
        }
    }
}
