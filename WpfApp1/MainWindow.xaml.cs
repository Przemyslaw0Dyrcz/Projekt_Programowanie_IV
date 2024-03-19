//poprawic tak kod aby nadawal id klientowi i status aktywny, poprawic kod DodajKlienta()





using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using WpfApp1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WypożyczalniaFilmów
{
    public partial class MainWindow : Window
    { private const string ConnectionString = "Data Source=DESKTOP-8EP9S8L;Initial Catalog=ProjektProgramowanie;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
            ZaladujKlientow();
            ZaladujFilmy();
            
        }


        private void ZaladujKlientow()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Klient";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Klient> customers = new List<Klient>();
                    while (reader.Read())
                    {
                        var customer = new Klient
                        {
                            IDklienta = Convert.ToInt32(reader["IDklienta"]),
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Pin = reader["Pin"].ToString(),
                            NrTelefonu = reader["NrTelefonu"].ToString(),
                            Adres = reader["Adres"].ToString(),
                            Status = reader["Status"].ToString(),
                            Pesel = reader["Pesel"].ToString()
                        };
                        customers.Add(customer);
                        
                    }
                    CustomerListBox.ItemsSource = customers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas wczytywania klientów: {ex.Message}");
                }
            }
        }

        private void ZaladujFilmy()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Film";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Film> movies = new List<Film>();
                    while (reader.Read())
                    {
                        var movie = new Film
                        {
                            IdFilmu = Convert.ToInt32(reader["IdFilmu"]),
                            Tytuł = reader["Tytuł"].ToString(),
                            Reżyser = reader["Reżyser"].ToString(),
                            RokProdukcji = Convert.ToInt32(reader["RokProdukcji"]),
                            CenaZaCykl = Convert.ToDecimal(reader["CenaZaCykl"]),
                            IlośćSztuk = Convert.ToInt32(reader["IlośćSztuk"])
                        };
                        movies.Add(movie);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas wczytywania filmów: {ex.Message}");
                }
            }
        }


public void DodajKlienta(string imie, string nazwisko, string pin, string nrTelefonu, string adres, string pesel)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                  
                    string query = "INSERT INTO Klient (Imie, Nazwisko, Pin, NrTelefonu, Adres, Status, Pesel) " +
                                   "VALUES ( @Imie, @Nazwisko, @Pin, @NrTelefonu, @Adres, @Status, @Pesel)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Imie", imie);
                    command.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    command.Parameters.AddWithValue("@Pin", pin);
                    command.Parameters.AddWithValue("@NrTelefonu", nrTelefonu);
                    command.Parameters.AddWithValue("@Adres", adres);
                    command.Parameters.AddWithValue("@Status", "aktywny"); // Dodaj status "aktywny"
                    command.Parameters.AddWithValue("@Pesel", pesel);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Klient został dodany pomyślnie.");
                        ZaladujKlientow();
                    }
                    else
                    {
                        MessageBox.Show("Dodawanie klienta nie powiodło się.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas dodawania klienta: {ex.Message}");
                }
            }
        }

        private void DodajFilm(string tytul, string autorzy, string rezyser, int rokProdukcji, decimal cenaZaCykl, int iloscSztuk, string opis)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Film (Tytuł, Autorzy, Reżyser, RokProdukcji, CenaZaCykl, IlośćSztuk, Opis) VALUES (@Tytuł, @Autorzy, @Reżyser, @RokProdukcji, @CenaZaCykl, @IlośćSztuk, @Opis)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tytuł", tytul);
                    command.Parameters.AddWithValue("@Autorzy", autorzy);
                    command.Parameters.AddWithValue("@Reżyser", rezyser);
                    command.Parameters.AddWithValue("@RokProdukcji", rokProdukcji);
                    command.Parameters.AddWithValue("@CenaZaCykl", cenaZaCykl);
                    command.Parameters.AddWithValue("@IlośćSztuk", iloscSztuk);
                    command.Parameters.AddWithValue("@Opis", opis);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Film został dodany pomyślnie.");
                        ZaladujFilmy();
                    }
                    else
                    {
                        MessageBox.Show("Dodawanie filmu nie powiodło się.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas dodawania filmu: {ex.Message}");
                }
            }
        }
        private void DodajNowegoKlienta_Click(object sender, RoutedEventArgs e)
        {
            FirstView firstView = new FirstView();
            firstView.DodanoKlienta += FirstView_DodanoKlienta;
            MainContent.Content = firstView;
        }
        private void FirstView_DodanoKlienta(object sender, EventArgs e)
        {

            FirstView firstView = (FirstView)sender;
            string imie = firstView.Imie;
            string nazwisko = firstView.Nazwisko;
            string pin = firstView.Pin;
            string nrTelefonu = firstView.NrTelefonu;
            string adres = firstView.Adres;
            string pesel = firstView.Pesel;

            DodajKlienta(imie, nazwisko, pin, nrTelefonu, adres, pesel);
            firstView.Visibility = Visibility.Collapsed;
            ZaladujKlientow();
        }
        private void Szukaj_Click(object sender, RoutedEventArgs e)
        {
            
            int searchedClientId;
            if (int.TryParse(SearchTextBox.Text, out searchedClientId))
            {
                
                var searchedClient = ((List<Klient>)CustomerListBox.ItemsSource).FirstOrDefault(c => c.IDklienta == searchedClientId);
                if (searchedClient != null)
                {
                    
                    CustomerListBox.SelectedItem = searchedClient;
                    CustomerListBox.ScrollIntoView(searchedClient);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono klienta o podanym IDklienta.");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź poprawny numer IDklienta.");
            }
        }
        private void KlienciListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CustomerListBox.SelectedItem != null)
            {
                var selectedCustomer = (Klient)CustomerListBox.SelectedItem;
                PokazLoginKlienta(selectedCustomer);
            }
        }

        private void PokazLoginKlienta(Klient selectedCustomer)
        {

            KlientLogowanie customerLoginWindow = new KlientLogowanie(selectedCustomer);
            customerLoginWindow.ShowDialog();
           
            MainWindow2 glownaApka = new MainWindow2(selectedCustomer);
            MainContent.Content = glownaApka;
        }

    }

}
