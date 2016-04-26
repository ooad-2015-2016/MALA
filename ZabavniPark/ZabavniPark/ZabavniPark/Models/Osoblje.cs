using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_OOAD.ParkBaza.Models
{
    public enum TipOsoblja { Radnik, SalterRadnik, Administrator };
    public class Osoblje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OsobljeId { get; set; }
        public String ime { get; set; }
        public String prezime { get; set;}
        public TipOsoblja tip { get; set;}
        public String username { get; set; }
        public String password { get; set; }
       public  int radniStaz { get; set; }

        
    }
}
