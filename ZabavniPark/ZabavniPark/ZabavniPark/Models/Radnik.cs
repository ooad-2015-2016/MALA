using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_OOAD.ParkBaza.Models
{
    public enum TipOsoblja { RadnikTeren, SalterRadnik, Administrator };
    public class Radnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RadnikId { get; set; } 
        public String Ime { get; set; }
        public String Prezime { get; set;}
        public TipOsoblja Tip { get; set;}
        public String Username { get; set; }
        public String Password { get; set; }
        public  int RadniStaz { get; set; }
        public double Plata { get; set; }


        public Radnik() { }
        public Radnik(int id, String ime, String prezime, TipOsoblja tip, String username, String pass, int god, double plata)
        {
            RadnikId = id;
            Ime = ime;
            Prezime = prezime;
            Tip = tip;
            Username = username;
            Password = pass;
            RadniStaz = god;
            Plata = plata;
        }    
    }
}
