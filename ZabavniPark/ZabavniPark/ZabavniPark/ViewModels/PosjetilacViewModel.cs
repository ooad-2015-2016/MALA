using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabavniPark.ZabavniPark.Models;

namespace ZabavniPark.ZabavniPark.ViewModels
{
    // nisam 100% sigurna, ali mislim da nam je ova klasa sad beskorisna, s obzirom da imamo RegistracijaPosjetilacViewModel
    public class PosjetilacViewModel
    {
        public Posjetilac Posjetilac { get; set; }

        public PosjetilacViewModel()
        {
            Posjetilac = new Posjetilac();
        }
    }
}
