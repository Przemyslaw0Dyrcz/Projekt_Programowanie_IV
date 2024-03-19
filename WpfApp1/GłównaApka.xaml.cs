using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System;
using WpfApp1;

namespace WypożyczalniaFilmów
{
    public partial class MainWindow2 : UserControl
    {
        private const string ConnectionString = "Data Source=DESKTOP-8EP9S8L;Initial Catalog=ProjektProgramowanie;Integrated Security=True";
        private Klient klient;
        public MainWindow2(Klient klient)
        {
            this.klient = klient;
            InitializeComponent();
            ZaładujDostepneFilmy();
        }

        private void ZaładujDostepnePlyty(string movieId)
        {
            PlytyZFilmami.Items.Clear(); 

            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Płyta WHERE IdFilmu = @MovieId AND Status = 'Dostępny'";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MovieId", movieId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var discId = reader["IdPłyty"].ToString();
                        PlytyZFilmami.Items.Add(discId); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas wczytywania płyt: {ex.Message}");
                }
            }
        }


        private void ZaładujDostepneFilmy()
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

            var selectedMovieTitle = AvailableMoviesListBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMovieTitle))
            {
                PokazInfoFilm(selectedMovieTitle);
            }
        }

        private void PokazInfoFilm(string movieTitle)
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
                        string opis = reader["Opis"].ToString();
                        MovieInfoTextBlock.Text = $"Tytuł: {title}\nReżyser: {director}\nOpis:{opis}\nCena za cykl: {price}";
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
            var selectedMovieTitle = AvailableMoviesListBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMovieTitle))
            {
                DodajWypozyczenie(klient.IDklienta, selectedMovieTitle);
            }
        }

        private void DodajWypozyczenie(int idKlienta, string tytulFilmu)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Wypożyczenie (DataWypożyczenia, IdKlienta, TytułFilmu) VALUES (@DataWypożyczenia, @IdKlienta, @TytułFilmu)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DataWypożyczenia", DateTime.Now);
                    command.Parameters.AddWithValue("@IdKlienta", idKlienta);
                    command.Parameters.AddWithValue("@TytułFilmu", tytulFilmu);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Wypożyczenie zostało dodane pomyślnie.");
                    }
                    else
                    {
                        MessageBox.Show("Dodawanie wypożyczenia nie powiodło się.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas dodawania wypożyczenia: {ex.Message}");
            }
        }

        private void PlytyZFilmami_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
