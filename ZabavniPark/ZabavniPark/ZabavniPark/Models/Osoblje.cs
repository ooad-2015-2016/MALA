using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_OOAD.ParkBaza.Models
{
    public enum TipOsoblja { Radnik, SalterRadnik, Administrator };
    class Osoblje
    {
      
        String ime;
        String prezime;
        TipOsoblja tip;
        String username;
        String password;
        int radniStaz;

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public TipOsoblja Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int RadniStaz
        {
            get
            {
                return radniStaz;
            }

            set
            {
                radniStaz = value;
            }
        }
    }
}
