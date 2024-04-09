using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektProgramowanie
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private Klient customer;
        private ContentControl mainContent;
        public Menu(Klient loggedCustomer, ContentControl mainContent)
        {
            InitializeComponent();
            customer = loggedCustomer;
            this.mainContent = mainContent;
        }

       // private void ListaWypozyczonychFilmow_Click(object sender, RoutedEventArgs e)
       // {
        //    mainContent.Content = new ListaWypozyczonychFilmowView().GetView();
       // }

        private void ZwrocFilm_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new WypozyczeniaKlienta(customer).GetView();
        }

        private void WypozyczFilm_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new MainWindow2(customer).GetView();
        }

    }
}
