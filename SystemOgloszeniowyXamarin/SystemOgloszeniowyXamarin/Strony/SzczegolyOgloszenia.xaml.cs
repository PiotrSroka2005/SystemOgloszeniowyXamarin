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
    public partial class SzczegolyOgloszenia : ContentPage
    {
        private ObservableCollection<Ogloszenie> ogloszenia;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public SzczegolyOgloszenia(int adm, bool log, string user, int IdOgloszenia)
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
                Aplikowanie.IsVisible = false;
                Wyl.IsVisible = false;
                uzytkownik.IsVisible = false;
                LiniaUser.IsVisible = false;
                profil.IsVisible = false;
            }
            else
            {
                uzytkownik.Text = user;
                LiniaUser.IsVisible = true;
                Aplikowanie.IsVisible = true;
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

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajSzczegolyOgloszenia(IdOgloszenia));
            ListaOgloszenia.ItemsSource = ogloszenia;
            ListaOgloszenia.BindingContext = ogloszenia;
        }

        public SzczegolyOgloszenia(int IdOgloszenia)
        {
            InitializeComponent();

            Aplikowanie.IsVisible = false;

            App.Baza.UtworzTabeleOgloszenia();
            Menu.IsVisible = false;

            uzytkownik.IsVisible = false;
            LiniaUser.IsVisible = false;
            PanelAdm.IsVisible = false;
            Wyl.IsVisible = false;
            profil.IsVisible = false;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajSzczegolyOgloszenia(IdOgloszenia));
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

        private void Profil_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilPage(admin, logged, usermn));
        }

        private void Aplikuj_Click(object sender, EventArgs e)
        {
            if (ogloszenia != null && ogloszenia.Count > 0 && logged)
            {
                try
                {
                    Ogloszenie wybraneOgloszenie = ogloszenia[0];
                    Uzytkownik zalogowanyUzytkownik = App.Baza.PobierzUzytkownika(usermn);

                    if (wybraneOgloszenie != null && zalogowanyUzytkownik != null)
                    {

                        bool juzAplikowano = App.Baza.CzyUzytkownikAplikowal(zalogowanyUzytkownik.Nick, wybraneOgloszenie.OgloszenieId);
                        if (!juzAplikowano)
                        {
                            App.Baza.DodajAplikacje(zalogowanyUzytkownik.Nick, zalogowanyUzytkownik.Email, wybraneOgloszenie.Tytul, wybraneOgloszenie.OgloszenieId);
                            DisplayAlert("Aplikacja została dodana.", "Info", "Ok");
                        }
                        else
                        {
                            Aplikowanie.Text = "Już aplikowano";
                            Aplikowanie.IsEnabled = false;
                            DisplayAlert("Już aplikowałeś na to ogłoszenie.", "Info" ,"Ok");
                        }
                    }
                    else
                    {
                        DisplayAlert("Wystąpił błąd podczas aplikowania na ogłoszenie. Spróbuj ponownie.", "Info", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert($"Wystąpił błąd: {ex.Message}", "Error", "Ok");
                }
            }
            else
            {
                DisplayAlert("Nie możesz aplikować na to ogłoszenie.", "Info", "Ok");
            }
        }
    }
}