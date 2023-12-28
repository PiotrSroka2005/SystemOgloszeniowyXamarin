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
	public partial class ZarzadzanieFirma : ContentPage
	{
        private ObservableCollection<Firma> firmy;

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public ZarzadzanieFirma(int adm, bool log, string user)
		{
			InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            firmy = new ObservableCollection<Firma>(App.Baza.CzytajFirmy());
            listaFirmy.ItemsSource = firmy;
        }

        private void Dodaj(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajFirme(admin, logged, usermn));
        }


        private void Usun(object sender, EventArgs e)
        {
            Firma firma = (Firma)listaFirmy.SelectedItem;

            if (firma != null)
            {
                App.Baza.UsunFirme(firma);
                firmy = new ObservableCollection<Firma>(App.Baza.CzytajFirmy());
                listaFirmy.ItemsSource = firmy;
            }            
            else
            {
                DisplayAlert("Proszę wybrać firme", "Info", "OK");
            }
        }

        private void Edytuj(object sender, EventArgs e)
        {
            Firma firma = (Firma)listaFirmy.SelectedItem;

            if (firma != null)
            {
                Navigation.PushAsync(new EdytujFirme(firma.FirmaId, firma.FirmaNazwa, admin, logged, usermn));             
            }
            else
            {
                DisplayAlert("Proszę wybrać firme", "Info", "OK");
            }
        }


        private void PanelAdmina_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage(admin, logged, usermn));
        }
    }
}