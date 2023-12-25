using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Registration Error", "Please enter a username and password.", "OK");
                return;
            }


            if (IsUsernameExistsInDatabase(username) == true)
            {
                if (IsPasswordCorrect(password) == true)
                {
                    var log = true;
                    var adm = 0;
                    string user = username;

                    if (IsAdmin(username) == true)
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



        private bool IsUsernameExistsInDatabase(string username)
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT COUNT() FROM uzytkownicy WHERE nick = @Username;";
                selectCommand.Parameters.AddWithValue("@Username", username);

                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                return count > 0;
            }
        }


        private bool IsPasswordCorrect(string password)
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT COUNT() FROM uzytkownicy WHERE haslo = @Password;";
                selectCommand.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                return count > 0;
            }
        }


        private bool IsAdmin(string username)
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();


                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT administrator FROM uzytkownicy WHERE Nick=@Nick";
                selectCommand.Parameters.AddWithValue("@Nick", username);



                int admin = Convert.ToInt32(selectCommand.ExecuteScalar());

                return admin > 0;
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