using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using SystemOgloszeniowyXamarin.Strony;
using SystemOgloszeniowyXamarin.Strony.Admin;
using Xamarin.Forms;

namespace SystemOgloszeniowyXamarin
{
    public partial class MainPage : ContentPage
    {     
        private List<Kategoria> kategorie;
        private ObservableCollection<Ogloszenie> ogloszenia;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";


        public MainPage()
        {
            InitializeComponent();

            Menu.IsVisible = false;

            App.Baza.UtworzTabeleFirmy();
            App.Baza.UtworzUzytkownikow();
            App.Baza.UtworzTabeleOgloszenia();

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWszystkieOgloszenia());
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;


            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            LogowanieLinia.IsVisible = false;
            PanelAdm.IsVisible = false;
            Wyl.IsVisible = false;
            profil.IsVisible = false;

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);

            KategoriaPicker.Title = "Wybierz kategorię";
            KategoriaPicker.ItemDisplayBinding = new Binding("KategoriaNazwa");
           

        }

        public MainPage(int adm, bool log, string user)
        {
            InitializeComponent();

            Menu.IsVisible = false;

            App.Baza.UtworzUzytkownikow();
            App.Baza.UtworzTabeleOgloszenia();
            App.Baza.UtworzTabeleAplikacje();            
            PanelAdm.IsVisible = false;
            usermn = user;
            admin = adm;
            logged = log;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWszystkieOgloszenia());
            ListaOgloszenia.ItemsSource = ogloszenia;
           

            if (logged == false)
            {
                Wyl.IsVisible = false;
                uzytkownik.IsVisible = false;
                LiniaUser.IsVisible = false;
                LogowanieLinia.IsVisible = false;
                profil.IsVisible = false;
            }
            else
            {
                uzytkownik.Text = user;
                LiniaUser.IsVisible = true;
                LogowanieLinia.IsVisible=true;
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

        

        private void Profil_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilPage(admin, logged, usermn));
        }

        private void ZalogujSie_Click(object sender, EventArgs e)
        {

            string adminUsername = "Delviner";
            string adminPassword = "Admin1234";
            string adminEmail = "delviner@interia.pl";

            if (!App.Baza.CzyIstniejeUzytkownik(adminUsername))
            {
                Uzytkownik adminUser = new Uzytkownik(adminUsername, adminPassword, adminEmail, true);
                App.Baza.DodajLubAktualizujUzytkownika(adminUser);
            }

            Navigation.PushAsync(new Logowanie());
        }

        private void WylogujSie_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage(admin,logged, usermn));
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

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

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
                       Navigation.PushAsync(new WyszukaneOgloszenia(admin, logged, usermn, zaznaczonaKategoriaId));

                    }
                    else
                    {
                        Navigation.PushAsync(new WyszukaneOgloszenia(admin, logged, usermn, Szukana, zaznaczonaKategoriaId));
                    }

                }
            }
            else
            {
                Navigation.PushAsync(new WyszukaneOgloszenia(admin, logged, usermn, Szukana));
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
