using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniPark.AtrakcijeBaza.Models
{
    class Atrakcija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AtrakcijaId { get; set; }//primary key u bazi
        public string fourSqaureId { get; set; }//trebati ce za sihronizaciju kasnije
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public TimeSpan VrijemeOtvaranja { get; set; }
        public TimeSpan VrijemeZatvaranja { get; set; }
        public int TrenutniBrojPosjetilaca { get; set; }
        public bool stanje { get; set; }
        public float Cijena { get; set; }
        public int BrojNaCekanju { get; set; }

    }
}
