using MyApp_OOAD.ParkBaza.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZabavniPark.ZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ParkoviListView : Page
    {
        public ParkoviListView()
        {
            this.InitializeComponent();
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ParkDbContext())
            {
                Park p = new Park();
                p.Naziv = NazivParkaTextBox.Text;
                p.Kapacitet = Int32.Parse(KapacitetParkaTextBox.Text);
                p.TrenutniBrojPosjetilaca = Int32.Parse(BrojPosjetilacaTextBox.Text);
                p.BrojRadnika = Int32.Parse(BrojRadnikaTextBox.Text);
                List<string> atrakcije = new List<string>();
                foreach (string s in AtrakcijeListBox.SelectedItems)
                    atrakcije.Add(s);
            
                db.Parkovi.Add(p);
                db.SaveChanges();

                //reset polja za unos
                NazivParkaTextBox.Text = string.Empty;
                KapacitetParkaTextBox.Text = string.Empty;
                BrojPosjetilacaTextBox.Text = string.Empty;
                BrojRadnikaTextBox.Text = string.Empty;

                //refresh liste restorana
                //RestoraniIS.ItemsSource = db.Restorani.OrderBy(c => c.Naziv).ToList();
            }
        }
    }
}
