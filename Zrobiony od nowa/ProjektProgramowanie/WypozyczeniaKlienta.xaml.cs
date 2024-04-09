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
    /// Logika interakcji dla klasy WypozyczeniaKlienta.xaml
    /// </summary>

    public partial class WypozyczeniaKlienta : UserControl,IView
    {
        private Klient customer;
        public UserControl GetView()
        {
            return this;
        }
        public WypozyczeniaKlienta(Klient loggedCustomer)
        {
            InitializeComponent();
            customer = loggedCustomer;
            DataContext = customer;
        }
    }
}
