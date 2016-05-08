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
        public String Ime { get; set; }
        public String Prezime { get; set;}
        public TipOsoblja Tip { get; set;}
        public String Username { get; set; }
        public String Password { get; set; }
        public  int RadniStaz { get; set; }
        public double Plata { get; set; }


        public Osoblje() { }

        // ovdje napraviti konstruktor koji prima sve parametre i postavlja gornje property-je na odgovarajucu vrijednost
        //public Osoblje()
        //{

        //}
       
    }
}
