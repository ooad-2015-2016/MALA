using NoviProjekatZabavniPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviProjekatZabavniPark.ViewModels
{
    public class PregledAtrakcijaViewModel
    {
        List<Atrakcija> Atrakcije;
         
        private int vrijemeCekanja;
        
        public int VrijemeCekanja
        {
            get { return vrijemeCekanja; }
            set { vrijemeCekanja = value; }
        }



        public PregledAtrakcijaViewModel()
        {

        }
    }
}
