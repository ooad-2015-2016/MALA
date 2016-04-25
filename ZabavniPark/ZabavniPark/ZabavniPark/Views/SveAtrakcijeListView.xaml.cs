using Microsoft.Data.Entity;
using MyApp_OOAD.AtrakcijaBaza.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class SveAtrakcijeListView : Page
    {
        //Potrebno je privremeno negdje staviti sliku koja se uploaduje
        private byte[] uploadSlika;
        public SveAtrakcijeListView()
        {
            this.InitializeComponent();
        }
        //pri load event povuci sve restorane i povezati ih sa list view
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new AtrakcijaDbContext())
            {
                SveAtrakcije.ItemsSource = db.SveAtrakcije.OrderBy(c => c.Naziv).ToList();
            }
        }
        //Event dodavanja novog Restorana
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AtrakcijaDbContext())
            {
                /*var contact = new Atrakcija
                {
                    Naziv = NazivInput.Text,
                    Telefon = TelefonInput.Text,
                    Opis = OpisInput.Text,
                    Rating = Convert.ToInt32(RatingInput.Text),
                    GeoDuzina = (float)Convert.ToDouble(GeoDuzinaInput.Text),
                    GeoSirina = (float)Convert.ToDouble(GeoSirinaInput.Text),
                    Slika = uploadSlika
                };
                db.Atrakcija.Add(contact);
                //SaveChanges obavezno da se reflektuju izmjene u bazi, tek tada dolazi do komunikacije sa bazom
 db.SaveChanges();
                //reset polja za unos
                NazivInput.Text = string.Empty;
                TelefonInput.Text = string.Empty;
                OpisInput.Text = string.Empty;
                RatingInput.Text = string.Empty;
                GeoDuzinaInput.Text = string.Empty;
                GeoSirinaInput.Text = string.Empty;
                //refresh liste restorana
                RestoraniIS.ItemsSource = db.Restorani.OrderBy(c => c.Naziv).ToList(); */
            }
        }
        
        //Event za brisanje restorana
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            //Dobavljanje objekta iz liste koji je kori[ten da se popuni red u listview
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            using (var db = new AtrakcijaDbContext())
            {
                db.SveAtrakcije.Remove((Atrakcija)SveAtrakcije.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save
                db.SaveChanges();
                //Refresh liste restorana
                SveAtrakcije.ItemsSource = db.SveAtrakcije.OrderBy(c => c.Naziv).ToList();
            }
        }
       
    }
}
