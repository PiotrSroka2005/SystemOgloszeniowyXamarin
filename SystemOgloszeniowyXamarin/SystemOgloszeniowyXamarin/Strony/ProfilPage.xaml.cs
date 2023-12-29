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
	public partial class ProfilPage : ContentPage
	{
        private ObservableCollection<Aplikacja> aplikacje;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public ProfilPage(int adm, bool log, string user)
		{
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            Menu.IsVisible = false;            
            PanelAdm.IsVisible = false;            

            if (logged == false)
            {
                Wyl.IsVisible = false;
                uzytkownik.IsVisible = false;
                LiniaUser.IsVisible = false;                
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
         
            aplikacje = new ObservableCollection<Aplikacja>(App.Baza.PobierzAplikacjeUzytkownika(usermn));
            AplikacjaWidok.ItemsSource = aplikacje;
            AplikacjaWidok.BindingContext = aplikacje;
        }

        private void Usun_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var aplikacja = button.BindingContext as Aplikacja;
                if (aplikacja != null)
                {
                    App.Baza.UsunAplikacje(aplikacja.IdOgloszenia, aplikacja.NazwaUzytkownika);
                    aplikacje.Remove(aplikacja);
                    AplikacjaWidok.ItemsSource = null;
                    AplikacjaWidok.ItemsSource = aplikacje;
                }
            }
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

    }
}