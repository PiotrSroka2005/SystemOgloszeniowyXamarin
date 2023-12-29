using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ZarzadzanieAdminem : ContentPage
	{
        private ObservableCollection<Uzytkownik> uzytkownicy;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public ZarzadzanieAdminem(int adm, bool log, string user)
		{
			InitializeComponent ();

            usermn = user;
            admin = adm;
            logged = log;

            uzytkownicy = new ObservableCollection<Uzytkownik>(App.Baza.CzytajWszystkichUzytkownikow());
            personsListView.ItemsSource = uzytkownicy;
        }

        private void GiveAdmin_Btn(object sender, EventArgs e)
        {
            var selected = personsListView.SelectedItem;
            Uzytkownik person = (Uzytkownik)selected;

            if (personsListView.SelectedItem != null)
            {
                person.Administrator = true;
                App.Baza.NadajUzytkownikowiAdmina(person);
                uzytkownicy = new ObservableCollection<Uzytkownik>(App.Baza.CzytajWszystkichUzytkownikow());
                personsListView.ItemsSource = uzytkownicy;
            }
        }

        private void RemoveAdmin_Btn(object sender, EventArgs e)
        {
            var selected = personsListView.SelectedItem;
            Uzytkownik person = (Uzytkownik)selected;

            if (personsListView.SelectedItem != null)
            {
                person.Administrator = false;
                App.Baza.NadajUzytkownikowiAdmina(person);
                uzytkownicy = new ObservableCollection<Uzytkownik>(App.Baza.CzytajWszystkichUzytkownikow());
                personsListView.ItemsSource = uzytkownicy;
            }
        }

        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage(admin, logged, usermn));
        }
    }
}