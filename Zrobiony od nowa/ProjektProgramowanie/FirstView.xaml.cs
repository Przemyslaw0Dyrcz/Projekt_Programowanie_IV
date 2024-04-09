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

            public void AddKlient_Click(object sender, RoutedEventArgs e)
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

