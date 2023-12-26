using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rejestracja : ContentPage
	{        
        public Rejestracja ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
                string username = UsernameEntry.Text;
                string password = PasswordEntry.Text;
                string email = EmailEntry.Text;
                bool administrator = false;

                Uzytkownik uzytkownik = new Uzytkownik(username, password, email, administrator);
                string patter = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    DisplayAlert("Wprowadź login i hasło.", "Registration Error", "OK");
                    return;
                }

                if (Regex.IsMatch(email, patter) == true)
                {
                    if (App.Baza.CzyIstniejeEmail(email) == true)
                    {
                        DisplayAlert("Taki email już istnieje. Jeśli masz już konto proszę się zalogować", "Registration Error", "OK");
                    }
                    else
                    {
                        if (App.Baza.CzyIstniejeUzytkownik(username) == true)
                        {
                            DisplayAlert("Taki użytkownik już istnieje", "Registration Error", "OK");
                        }
                        else
                        {
                            App.Baza.DodajLubAktualizujUzytkownika(uzytkownik);

                            DisplayAlert("Rejestreacja przebiegła pomyślnie.", "Registration", "OK");

                            UsernameEntry.Text = string.Empty;
                            PasswordEntry.Text = string.Empty;
                            EmailEntry.Text = string.Empty;

                            Navigation.PushAsync(new Logowanie());

                        }
                    }
                }
                else
                {
                    DisplayAlert("Proszę podać poprawny email", "Registration Error", "OK");
                }                        
        }

        private void ZalogujSie_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Logowanie());
        }

        private void StronaGlowna(object sender, EventArgs e)
        {
            int adm = 0;
            bool log = false;
            string user = "";
            Navigation.PushAsync(new MainPage(adm, log, user));
        }
    }
}