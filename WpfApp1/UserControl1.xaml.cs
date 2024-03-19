using System;
using System.Windows;
using System.Windows.Controls;
using WypożyczalniaFilmów;

namespace WpfApp1
{
    public partial class FirstView : UserControl
    {
        // Dodaj pola dla przechowywania danych klienta
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pin { get; set; }
        public string NrTelefonu { get; set; }
        public string Adres { get; set; }
        public string Pesel { get; set; }

        public event EventHandler DodanoKlienta;

        public FirstView()
        {
            InitializeComponent();
        }

        public void DodajKlienta_Click(object sender, RoutedEventArgs e)
        {
            // Przypisz dane klienta do właściwości
            Imie = ImieTextBox.Text;
            Nazwisko = NazwiskoTextBox.Text;
            Pin = PinTextBox.Password;
            NrTelefonu = NrTelefonuTextBox.Text;
            Adres = AdresTextBox.Text;
            Pesel = PeselTextBox.Text;


            DodanoKlienta?.Invoke(this, EventArgs.Empty);
            
        }


        private void AdresTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NazwiskoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
