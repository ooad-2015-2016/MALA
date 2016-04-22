using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_OOAD.ParkBaza.Models
{
    class Park
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkId { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public int TrenutniBrojPosjetilaca { get; set; }
        public int BrojRadnika { get; set; }
        public List<string> Atrakcije { get; set; }
    }
}