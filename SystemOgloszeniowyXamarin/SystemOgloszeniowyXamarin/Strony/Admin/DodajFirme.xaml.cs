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
	public partial class DodajFirme : ContentPage
	{
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public DodajFirme(int adm, bool log, string user)
		{
			InitializeComponent ();

            usermn = user;
            admin = adm;
            logged = log;
        }


        private void DodajFirm(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            int id = 0;
            Firma firma = new Firma(id, name);

            App.Baza.DodajFirme(firma);

            NameEntry.Text = string.Empty;
        }

        private void ZarzadzajFirmami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ZarzadzanieFirma(admin, logged, usermn));
        }
    }
}