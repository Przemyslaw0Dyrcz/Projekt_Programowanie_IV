using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjektProgramowanie;

namespace ProjektProgramowanie
{
    public partial class MainWindow2 : UserControl,IView
    {
        private Model1 dbContext;
        private Klient klient;

        public MainWindow2(Klient klient)
        {
            this.klient = klient;
            InitializeComponent();
            dbContext = new Model1();
            LoadAvailableVideos();
        }
        public UserControl GetView()
        {
            return this;
        }
        private void LoadAvailableDiscs(int movieId)
        {
            PlytyZFilmami.Items.Clear();

            try
            {
                var availableDiscs = dbContext.PłytaZFilmem.Where(p => p.IdFilmu == movieId && p.Status == "Dostępny").ToList();
                foreach (var disc in availableDiscs)
                {
                    PlytyZFilmami.Items.Add(disc.IDplyty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wczytywania płyt: {ex.Message}");
            }
        }

        private void LoadAvailableVideos()
        {
            try
            {
                var movies = dbContext.Film.Select(f => f.Tytuł).ToList();
                foreach (var movie in movies)
                {
                    AvailableMoviesListBox.Items.Add(movie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wczytywania filmów: {ex.Message}");
            }
        }


        private void AvailableMoviesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMovieTitle = AvailableMoviesListBox.SelectedItem?.ToString();

            var selectedMovie = dbContext.Film.FirstOrDefault(f => f.Tytuł == selectedMovieTitle);

            if (selectedMovie != null)
            {
                MovieInfoTextBlock.Text = $"Tytuł: {selectedMovie.Tytuł}\nReżyser: {selectedMovie.Reżyser}\nOpis:{selectedMovie.Opis}\nCena za cykl: {selectedMovie.CenaZaCykl}";

                LoadAvailableDiscs(selectedMovie.IdFilmu);
            }
        }


        private void WypozyczButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMovieTitle = AvailableMoviesListBox.SelectedItem?.ToString();
            var selectedDiscId = PlytyZFilmami.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedMovieTitle) && !string.IsNullOrEmpty(selectedDiscId))
            {
                AddWypozyczenie(klient.IDklienta, selectedMovieTitle, selectedDiscId);
            }
        }


        private void AddWypozyczenie(int idKlienta, string movieTitle, string discId)
        {
            try
            {
                var selectedMovie = dbContext.Film.FirstOrDefault(f => f.Tytuł == movieTitle);
                if (selectedMovie != null)
                {
                    int discIdInt = Convert.ToInt32(discId);

                    var selectedDisc = dbContext.PłytaZFilmem.FirstOrDefault(p => p.IDplyty == discIdInt && p.Status == "Dostępny");
                    if (selectedDisc != null)
                    {
                        selectedDisc.Status = "Niedostępny"; 

                        var newRental = new Wypożyczenie
                        {
                            DataWypożyczenia = DateTime.Now,
                            IDklienta = idKlienta,
                            IDplyty = discIdInt
                        };

                        dbContext.Wypożyczenie.Add(newRental);
                        dbContext.SaveChanges();

                        MessageBox.Show("Wypożyczenie zostało dodane pomyślnie.");
                    }
                    else
                    {
                        MessageBox.Show("Wybrana płyta jest już niedostępna lub nie istnieje.");
                    }
                }
                else
                {
                    MessageBox.Show("Nie można znaleźć wybranego filmu.");
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
