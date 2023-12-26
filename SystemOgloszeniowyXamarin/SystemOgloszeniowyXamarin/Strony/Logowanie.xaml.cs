using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Logowanie : ContentPage
	{
		public Logowanie ()
		{
			InitializeComponent ();
		}

        private void Rejestracja(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Rejestracja());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Registration Error", "Please enter a username and password.", "OK");
                return;
            }


            if (App.Baza.IsUsernameExistsInDatabase(username) == true)
            {
                if (App.Baza.IsPasswordCorrect(password) == true)
                {
                    var log = true;
                    var adm = 0;
                    string user = username;

                    if (App.Baza.IsAdmin(username) == true)
                    {

                        adm = 1;
                        Navigation.PushAsync(new MainPage(adm, log, user));
                    }
                    else
                    {
                        Navigation.PushAsync(new MainPage(adm, log, user));
                    }
                }
                else
                {
                    DisplayAlert("Loginb Error", "Podano niepoprawne haslo", "OK");
                }

            }
            else
            {
                DisplayAlert("Loginb Error", "Podano niepoprawny login", "OK");
            }

        }

        private void StronaGlowna(object sender, EventArgs e)
        {
            int adm = 0;
            bool log = false;
            string user = "";
            Navigation.PushAsync(new MainPage(adm,log,user));
        }
    }
}