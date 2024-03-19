using System.Windows.Controls;
using System.Windows;
using WpfApp1;
namespace WypożyczalniaFilmów
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