using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DodajKategorie : ContentPage
	{
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public DodajKategorie(int adm, bool log, string user)
		{
			InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;
        }

        private void DodajKat(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            int id = 0;
            Kategoria kategoria = new Kategoria(id, name);

            App.Baza.DodajKategorie(kategoria);

            NameEntry.Text = string.Empty;
        }

        private void ZarzadzajKategoriami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ZarzadzanieKategoria(admin, logged, usermn));
        }
    }
}