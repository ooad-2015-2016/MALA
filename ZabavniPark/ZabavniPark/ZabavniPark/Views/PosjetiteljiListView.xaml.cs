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

using ZabavniPark.ZabavniPark.Models;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ZabavniPark.ZabavniPark.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PosjetiteljiListView : Page
    {
        public PosjetiteljiListView()
        {
            this.InitializeComponent();
        }

       /* private void Page_loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new PosjetilacDbContext())
            {
                
            }
}
*/
        private void DodajKlik(object sender, RoutedEventArgs e)
        {
            Posjetilac p = new Posjetilac();
            p.Ime = ImePosjetiteljaTextBox.Text.ToString();
            p.Prezime = PrezimePosjetiteljaTextBlock.Text.ToString();
            if (ObicniPosjetiteljRB.IsChecked == true)
                p.tip = TipPosjetilaca.Obicni;
            else if (RegistrovaniPosjetiteljRB.IsChecked == true)
                p.tip = TipPosjetilaca.Registrovani;
            else if (GoldPosjetiteljRB.IsChecked == true)
                p.tip = TipPosjetilaca.Gold;

            using (var db = new PosjetilacDbContext())
            {
                db.Posjetioci.Add(p);
                db.SaveChanges();
                
            }

        }
    }
}
