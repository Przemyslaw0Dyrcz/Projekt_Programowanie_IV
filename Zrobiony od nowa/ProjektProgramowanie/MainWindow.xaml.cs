using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjektProgramowanie;

namespace ProjektProgramowanie
{

    public partial class MainWindow : Window
    {
        
        private Model1 dbContext;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new Model1();
            LoadKlient();
            LoadFilms();

        }


        private void LoadKlient()
        {
            try
            {
                List<Klient> customers = dbContext.Klient.ToList();
                CustomerListBox.ItemsSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wczytywania klientów: {ex.Message}");
            }
        }

        private void LoadFilms()
        {
            try
            {
                List<Film> movies = dbContext.Film.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wczytywania filmów: {ex.Message}");
            }
        }


        public void AddKlient(string imie, string nazwisko, string pin, string nrTelefonu, string adres, string pesel)
        {
            try
            {
                Klient newCustomer = new Klient
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Pin = pin,
                    NrTelefonu = nrTelefonu,
                    Adres = adres,
                    Status = "aktywny", // Dodaj status "aktywny"
                    Pesel = pesel
                };

                dbContext.Klient.Add(newCustomer);
                dbContext.SaveChanges();
                MessageBox.Show("Klient został dodany pomyślnie.");
                LoadKlient();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas dodawania klienta: {ex.Message}");
            }
        }

        private void DodajFilm(string tytul, string autorzy, string rezyser, int rokProdukcji, decimal cenaZaCykl, int iloscSztuk, string opis)
        {
            try
            {
                Film newMovie = new Film
                {
                    Tytuł = tytul,
                    Reżyser = rezyser,
                    RokProdukcji = rokProdukcji,
                    CenaZaCykl = cenaZaCykl,
                    IlośćSztuk = iloscSztuk,
                    Opis = opis
                };

                dbContext.Film.Add(newMovie);
                dbContext.SaveChanges();
                MessageBox.Show("Film został dodany pomyślnie.");
                LoadFilms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas dodawania filmu: {ex.Message}");
            }
        }
        private void AddNewKlient_Click(object sender, RoutedEventArgs e)
        {
            FirstView firstView = new FirstView();
            firstView.DodanoKlienta += FirstView_AddedKlient;
            MainContent.Content = firstView;
        }
        private void FirstView_AddedKlient(object sender, EventArgs e)
        {

            FirstView firstView = (FirstView)sender;
            string imie = firstView.Imie;
            string nazwisko = firstView.Nazwisko;
            string pin = firstView.Pin;
            string nrTelefonu = firstView.NrTelefonu;
            string adres = firstView.Adres;
            string pesel = firstView.Pesel;

            AddKlient(imie, nazwisko, pin, nrTelefonu, adres, pesel);
            firstView.Visibility = Visibility.Collapsed;
            LoadKlient();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
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

            Menu menu = new Menu(selectedCustomer, MainContent);
            MainContent.Content = menu;
        }
    }
}