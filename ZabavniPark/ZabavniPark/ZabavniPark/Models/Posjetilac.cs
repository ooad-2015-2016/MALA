using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.ZabavniPark.Models
{
    public enum TipPosjetilaca { Obicni, Registrovani, Gold}
    class Posjetilac
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PosjetilacId { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public TipPosjetilaca tip { get; set; }
    }
}
