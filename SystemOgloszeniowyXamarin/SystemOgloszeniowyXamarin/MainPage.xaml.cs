using System;
using System.Collections.Generic;
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
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";


        public MainPage()
        {
            InitializeComponent();

            Menu.IsVisible = false;


            App.Baza.UtworzUzytkownikow();
            App.Baza.UtworzTabeleOgloszenia();

            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            PanelAdm.IsVisible = false;
            Wyl.IsVisible = false;
            profil.IsVisible = false;

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;
            
        }

        public MainPage(int adm, bool log, string user)
        {
            InitializeComponent();

            Menu.IsVisible = false;

            App.Baza.UtworzTabeleAplikacje();            
            PanelAdm.IsVisible = false;
            usermn = user;
            admin = adm;
            logged = log;


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

            App.Baza.UtworzUzytkownikow();
            App.Baza.UtworzTabeleOgloszenia();

            kategorie = App.Baza.CzytajKategorie();
            KategoriaPicker.ItemsSource = kategorie;
            
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
            //ProfilWindow p = new ProfilWindow(admin, logged, usermn);
            //p.Show();
            //this.Close();
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
