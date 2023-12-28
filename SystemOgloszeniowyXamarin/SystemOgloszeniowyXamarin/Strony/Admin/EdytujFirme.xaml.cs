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
	public partial class EdytujFirme : ContentPage
	{
        private int _id;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public EdytujFirme(int id, string nazwa, int adm, bool log, string user)
		{
			InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            NameEntry.Text = nazwa;
            _id = id;
        }


        private void EdytujFirm(object sender, EventArgs e)
        {
            string nazwa = NameEntry.Text;


            if (!string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                int id = _id;


                Firma firm = new Firma();
                firm.FirmaId = id;
                firm.FirmaNazwa = nazwa;


                App.Baza.AktualizujFirme(firm);

                DisplayAlert("Firma została zaktualizowana", "Info", "OK");
            }
            else
            {
                DisplayAlert("Proszę uzupełnic pola", "Info", "OK");
            }
        }

        private void ZarzadzajFirmami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ZarzadzanieFirma(admin, logged, usermn));
        }
    }
}