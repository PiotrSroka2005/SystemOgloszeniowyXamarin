using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using SystemOgloszeniowyXamarin.Strony;
using Xamarin.Forms;

namespace SystemOgloszeniowyXamarin
{
    public partial class MainPage : ContentPage
    {

        private List<Kategoria> kategorie;
        private bool isPanelExpanded = false;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";


        public MainPage()
        {
            InitializeComponent();

            Menu.IsVisible = false;

           
            Baza.TabelaUzytkownikow();
            Baza.TabelaOgloszenia();

            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            //PanelAdm.Visibility = Visibility.Collapsed;
            //Wyl.Visibility = Visibility.Collapsed;
            //profil.Visibility = Visibility.Collapsed;

            //MainViewModel viewModel = new MainViewModel();
            //DataContext = viewModel;

            //kategorie = Baza.CzytajKategorie();

            //Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            //kategorie.Insert(0, specjalnaKategoria);

            //KategoriaComboBox.ItemsSource = kategorie;

            //// Wczytaj ogłoszenia
            //viewModel.Ogloszenia = Baza.CzytajWszystkieOgloszenia();


        }

        public MainPage(int adm, bool log, string user)
        {
            InitializeComponent();
           

            Baza.UtworzTabeleAplikacji();
            Baza.UtworzTabeleAplikacji();
            //PanelAdm.Visibility = Visibility.Collapsed;
            //usermn = user;
            //admin = adm;
            //logged = log;


            //if (logged == false)
            //{
            //    Wyl.Visibility = Visibility.Collapsed;
            //    uzytkownik.Visibility = Visibility.Collapsed;
            //    profil.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    uzytkownik.Header = user;
            //    Zal.Visibility = Visibility.Collapsed;
            //    if (admin == 1)
            //    {
            //        PanelAdm.Visibility = Visibility.Visible;
            //    }
            //    else
            //    {
            //        PanelAdm.Visibility = Visibility.Collapsed;
            //    }
            //}

            Baza.TabelaUzytkownikow();
            Baza.TabelaOgloszenia();

            kategorie = Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;
            //Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            //kategorie.Insert(0, specjalnaKategoria);

            //KategoriaComboBox.ItemsSource = kategorie;

            //MainViewModel viewModel = new MainViewModel();
            //DataContext = viewModel;

            //// Wczytaj ogłoszenia
            //viewModel.Ogloszenia = Baza.CzytajWszystkieOgloszenia();
        }

        private void Menu_Clicked(object sender, EventArgs e)
        {
            //if(Menu.IsVisible == false)
            //{
            //    Menu.ScaleY = 0;
            //    Menu.ScaleYTo(1, 1000, Easing.SinInOut);

            //    Menu.IsVisible = true;
            //}
            //else
            //{
            //    Menu.ScaleYTo(0, 1000, Easing.SinInOut);
            //    Menu.IsVisible = false;
            //}

            if (Menu.IsVisible == false)
            {                
                Menu.IsVisible = true;
                Menu.ScaleY = 0;
                Menu.ScaleYTo(1, 5000, Easing.SinInOut);
            } 
            else 
            {
                Menu.IsVisible = false;
                Menu.ScaleYTo(0, 5000, Easing.SinInOut);
            }
        }

        

        private void Profil_Click(object sender, EventArgs e)
        {
            //ProfilWindow p = new ProfilWindow(admin, logged, usermn);
            //p.Show();
            //this.Close();
        }

        private void ZalogujSie_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Logowanie());
        }

        private void WylogujSie_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            //AdminWindow d = new AdminWindow(admin, logged, usermn);
            //d.Show();
            //this.Close();
        }
     
        private void Szczegoly_Click(object sender, EventArgs e)
        {
            //Button button = sender as Button;


            //Ogloszenie ogloszenie = button?.DataContext as Ogloszenie;


            //if (ogloszenie != null)
            //{
            //    int idOgloszenia = ogloszenie.OgloszenieId;


            //    SzczegolyOgloszenia szczegolyWindow = new SzczegolyOgloszenia(admin, logged, usermn, idOgloszenia);
            //    szczegolyWindow.Show();
            //    this.Close();
            //}
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void Szukaj_Clicked(object sender, EventArgs e)
        {
            string Szukana = searchBar.Text;

            //if (KategoriaComboBox.SelectedIndex != -1 && KategoriaComboBox.SelectedIndex != 0)
            //{
            //    var zaznaczonaKategoria = KategoriaComboBox.SelectedItem as Kategoria;
            //    if (zaznaczonaKategoria != null)
            //    {
            //        int zaznaczonaKategoriaId = zaznaczonaKategoria.KategoriaId;
            //        if (searchBar.Text == "")
            //        {
            //            WyszukaneOgloszenia w = new WyszukaneOgloszenia(admin, logged, usermn, zaznaczonaKategoriaId);
            //            w.Show();
            //            this.Close();
            //        }
            //        else
            //        {
            //            WyszukaneOgloszenia w = new WyszukaneOgloszenia(admin, logged, usermn, Szukana, zaznaczonaKategoriaId);
            //            w.Show();
            //            this.Close();
            //        }

            //    }
            //}
            //else
            //{
            //    WyszukaneOgloszenia z = new WyszukaneOgloszenia(admin, logged, usermn, Szukana);
            //    z.Show();
            //    this.Close();
            //}
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
