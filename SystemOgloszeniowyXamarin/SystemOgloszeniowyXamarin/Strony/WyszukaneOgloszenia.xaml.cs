using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using SystemOgloszeniowyXamarin.Strony.Admin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WyszukaneOgloszenia : ContentPage
    {
        private List<Kategoria> kategorie;
        private ObservableCollection<Ogloszenie> ogloszenia;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        private string szukana = "";
        private int wybranaKategoria = 0;
        public WyszukaneOgloszenia(string Szukana)
        {
            InitializeComponent();

            App.Baza.UtworzTabeleOgloszenia();
            Menu.IsVisible = false;
            
            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            PanelAdm.IsVisible = false;
            Wyl.IsVisible = false;
            profil.IsVisible = false;

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");

            
            szukana = Szukana;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszeniaSzukana(szukana));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        public WyszukaneOgloszenia(int WybranaKategoria)
        {
            InitializeComponent();

            App.Baza.UtworzTabeleOgloszenia();

            Menu.IsVisible = false;

           
            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            PanelAdm.IsVisible = false;
            Wyl.IsVisible = false;
            profil.IsVisible = false;

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");


            wybranaKategoria = WybranaKategoria;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszeniaKategoria(wybranaKategoria));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        public WyszukaneOgloszenia(int adm, bool log, string user, string Szukana)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            App.Baza.UtworzTabeleOgloszenia();

            Menu.IsVisible = false;
            PanelAdm.IsVisible = false;
            if (logged == false)
            {
                Wyl.IsVisible = false;
                uzytkownik.IsVisible = false;
                LiniaUser.IsVisible = false;
                profil.IsVisible = false;
            }
            else
            {
                uzytkownik.Text = user;
                LiniaUser.IsVisible = true;
                Zal.IsVisible = false;
                if (admin == 1)
                {
                    PanelAdm.IsVisible = true;
                }
                else
                {
                    PanelAdm.IsVisible = false;
                }
            }

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");
           
            szukana = Szukana;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszeniaSzukana(szukana));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        public WyszukaneOgloszenia(int adm, bool log, string user, int WybranaKategoria)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            App.Baza.UtworzTabeleOgloszenia();
            PanelAdm.IsVisible = false;

            Menu.IsVisible = false;

            if (logged == false)
            {
                Wyl.IsVisible = false;
                uzytkownik.IsVisible = false;
                LiniaUser.IsVisible = false;
                profil.IsVisible = false;
            }
            else
            {
                uzytkownik.Text = user;
                LiniaUser.IsVisible = true;
                Zal.IsVisible = false;
                if (admin == 1)
                {
                    PanelAdm.IsVisible = true;
                }
                else
                {
                    PanelAdm.IsVisible = false;
                }
            }

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");

            

            wybranaKategoria = WybranaKategoria;


            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszeniaKategoria(wybranaKategoria));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        public WyszukaneOgloszenia(string Szukana, int WybranaKategoria)
        {
            InitializeComponent();

            App.Baza.UtworzTabeleOgloszenia();
            Menu.IsVisible = false;

            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            PanelAdm.IsVisible = false;
            Wyl.IsVisible = false;
            profil.IsVisible = false;

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");
            
            szukana = Szukana;
            wybranaKategoria = WybranaKategoria;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszenia(szukana, wybranaKategoria));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        public WyszukaneOgloszenia(int adm, bool log, string user, string Szukana, int WybranaKategoria)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            Menu.IsVisible = false;
            App.Baza.UtworzTabeleOgloszenia();
            PanelAdm.IsVisible = false;

            if (logged == false)
            {
                Wyl.IsVisible = false;
                uzytkownik.IsVisible = false;
                LiniaUser.IsVisible = false;
                profil.IsVisible = false;
            }
            else
            {
                uzytkownik.Text = user;
                LiniaUser.IsVisible = true;
                Zal.IsVisible = false;
                if (admin == 1)
                {
                    PanelAdm.IsVisible = true;
                }
                else
                {
                    PanelAdm.IsVisible = false;
                }
            }

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;
           
            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");

            szukana = Szukana;
            wybranaKategoria = WybranaKategoria;


            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszenia(szukana, wybranaKategoria));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        private void ZalogujSie_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Logowanie());
        }

        private void WylogujSie_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void StronaGlowna_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(admin, logged, usermn));
        }

        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage(admin, logged, usermn));

        }
    
        private void Menu_Clicked(object sender, EventArgs e)
        {
            if (Menu.IsVisible == false)
            {
                Menu.IsVisible = true;
            }
            else
            {
                Menu.IsVisible = false;
            }
        }


        private void Szczegoly_Click(object sender, EventArgs e)
        {
            var frame = sender as Frame;

            if (frame != null && frame.BindingContext is Ogloszenie ogloszenie)
            {
                int idOgloszenia = ogloszenie.OgloszenieId;

                Navigation.PushAsync(new SzczegolyOgloszenia(admin, logged, usermn, idOgloszenia));
            }
        }


        private void Profil_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilPage(admin, logged, usermn));
        }

        private void Szukaj_Clicked(object sender, EventArgs e)
        {
            string Szukana = searchBar.Text;
          

            if(KategoriaPicker.SelectedIndex != -1 && KategoriaPicker.SelectedIndex != 0)
            {
                var zaznaczonaKategoria = KategoriaPicker.SelectedItem as Kategoria;
                if (zaznaczonaKategoria != null)
                {
                    int zaznaczonaKategoriaId = zaznaczonaKategoria.KategoriaId;
                    if (searchBar.Text == "")
                    {
                        ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszeniaKategoria(zaznaczonaKategoriaId));
                        ListaOgloszenia.ItemsSource = ogloszenia;
                        ListaOgloszenia.BindingContext = ogloszenia;
                    }
                    else
                    {
                        ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszenia(Szukana, zaznaczonaKategoriaId));
                        ListaOgloszenia.ItemsSource = ogloszenia;
                        ListaOgloszenia.BindingContext = ogloszenia;
                    }

                }
            }
            else
            {
                ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWyszukaneOgloszeniaSzukana(Szukana));
                ListaOgloszenia.ItemsSource = ogloszenia;
                ListaOgloszenia.BindingContext = ogloszenia;
            }
        }
    }
}