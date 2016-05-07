using MyApp_OOAD.AtrakcijaBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    public class AtrakcijaViewModel
    {
        public Atrakcija Atrakcija { get; set; }
        //public INavigationService NavigationService { get; set; }

        public AtrakcijaViewModel()
        {
            Atrakcija = new Atrakcija();
        }

    }
}
