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
using System.Windows.Shapes;

namespace ProjektProgramowanie
{
    public partial class KlientLogowanie : Window
    {
        private Klient selectedCustomer;

        public KlientLogowanie(Klient customer)
        {
            InitializeComponent();
            selectedCustomer = customer;
        }

        private void LogowanieButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredPassword = PasswordBox1.Password;


            if (enteredPassword == selectedCustomer.Pin)
            {
                MessageBox.Show("Logowanie udane!");
                this.Close();


            }
            else
            {
                MessageBox.Show("Błędne hasło. Spróbuj ponownie.");
            }
        }
    }
}
