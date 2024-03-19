using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System;

namespace WypożyczalniaFilmów
{
    public partial class MainWindow1 : Window
    {
        private const string ConnectionString = "Data Source=DESKTOP-8EP9S8L;Initial Catalog=ProjektProgramowanie;Integrated Security=True";

        public MainWindow1()
        {
            InitializeComponent();
            ZaladujDostepneFilmy();
        }

        private void ZaladujDostepneFilmy()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Film";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var movieTitle = reader["Tytuł"].ToString();
                        AvailableMoviesListBox.Items.Add(movieTitle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas wczytywania filmów: {ex.Message}");
                }
            }
        }

        private void WypozyczFilm_Click(object sender, RoutedEventArgs e)
        {

            var wybranyTytul = AvailableMoviesListBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(wybranyTytul))
            {
                PokazInfoOFilmie(wybranyTytul);
            }
        }

        private void PokazInfoOFilmie(string movieTitle)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Film WHERE Tytuł = @MovieTitle";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MovieTitle", movieTitle);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string title = reader["Tytuł"].ToString();
                        string director = reader["Reżyser"].ToString();
                        decimal price = Convert.ToDecimal(reader["CenaZaCykl"]);

                        MovieInfoTextBlock.Text = $"Tytuł: {title}\nReżyser: {director}\nCena za cykl: {price}";

                     
                        WypozyczButton.IsEnabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas pobierania informacji o filmie: {ex.Message}");
                }
            }
        }

        private void WypozyczButton_Click(object sender, RoutedEventArgs e)
        {
         
            MessageBox.Show("Film został wypożyczony!");
        }
    }
}

