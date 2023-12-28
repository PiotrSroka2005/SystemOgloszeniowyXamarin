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
	public partial class ZarzadzanieKategoria : ContentPage
	{
        private ObservableCollection<Kategoria> kategorie;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public ZarzadzanieKategoria(int adm, bool log, string user)
		{
			InitializeComponent ();

            usermn = user;
            admin = adm;
            logged = log;

            kategorie = new ObservableCollection<Kategoria>(App.Baza.CzytajKategorie());
            listaKategorie.ItemsSource = kategorie;
        }

        private void Dodaj(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajKategorie(admin, logged, usermn));
        }


        private void Usun(object sender, EventArgs e)
        {
            Kategoria kategoria = (Kategoria)listaKategorie.SelectedItem;
            if (kategoria != null)
            {                
                App.Baza.UsunKategorie(kategoria);
                kategorie = new ObservableCollection<Kategoria>(App.Baza.CzytajKategorie());
                listaKategorie.ItemsSource = kategorie;
            }
            else
            {
                DisplayAlert("Proszę wybrać kategorie", "Info", "OK");
            }
        }

        private void Edytuj(object sender, EventArgs e)
        {
            Kategoria kategoria = (Kategoria)listaKategorie.SelectedItem;

            if (kategoria != null)
            {
                Navigation.PushAsync(new EdytujKategorie(kategoria.KategoriaId, kategoria.KategoriaNazwa, admin, logged, usermn));
            }
            else
            {
                DisplayAlert("Proszę wybrać kategorie", "Info", "OK");
            }
        }


        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage(admin, logged, usermn));
        }
    }
}