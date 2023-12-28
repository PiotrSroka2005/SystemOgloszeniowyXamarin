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
	public partial class ZarzadzanieOgloszeniami : ContentPage
	{
        private ObservableCollection<Ogloszenie> ogloszenia;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public ZarzadzanieOgloszeniami(int adm, bool log, string user)
		{
			InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWszystkieOgloszenia());
            listaOgloszenia.ItemsSource = ogloszenia;
        }

        private void Dodaj(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajOgloszenie(admin, logged, usermn));
        }

        private void Usun(object sender, EventArgs e)
        {

            Ogloszenie ogloszenie = (Ogloszenie)listaOgloszenia.SelectedItem;

            if (ogloszenie != null)
            {
                App.Baza.UsunOgloszenie(ogloszenie);
                ogloszenia = new ObservableCollection<Ogloszenie>(App.Baza.CzytajWszystkieOgloszenia());
                listaOgloszenia.ItemsSource = ogloszenia;
            }
            else
            {
                DisplayAlert("Proszę wybrać ogloszenie", "Info", "OK");
            }

        }

        private void Edytuj(object sender, EventArgs e)
        {
            Ogloszenie ogloszenie = (Ogloszenie)listaOgloszenia.SelectedItem;

            if (ogloszenie != null)
            {
                Navigation.PushAsync(new EdytujOgloszenie(ogloszenie.OgloszenieId, ogloszenie.KategoriaId, ogloszenie.FirmaId, ogloszenie.Tytul, ogloszenie.NazwaStanowiska, ogloszenie.PoziomStanowiska, ogloszenie.RodzajPracy, ogloszenie.WymiarZatrudnienia,
                ogloszenie.RodzajUmowy, ogloszenie.NajmniejszeWynagrodzenie, ogloszenie.NajwiekszeWynagrodzenie, ogloszenie.DniPracy, ogloszenie.GodzinyPracy, ogloszenie.DataWaznosci, ogloszenie.Obowiazki, ogloszenie.Wymagania, ogloszenie.Benefity, ogloszenie.Informacje, ogloszenie.DataUtworzenia, ogloszenie.Zdjecie, admin, logged, usermn));
            }
            else
            {
                DisplayAlert("Proszę wybrać ogloszenie", "Info", "OK");
            }
        }

        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage(admin, logged, usermn));
        }
    }
}