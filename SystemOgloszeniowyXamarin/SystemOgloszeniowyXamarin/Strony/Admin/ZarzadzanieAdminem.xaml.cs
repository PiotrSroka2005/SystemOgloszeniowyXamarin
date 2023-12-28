using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ZarzadzanieAdminem : ContentPage
	{
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public ZarzadzanieAdminem(int adm, bool log, string user)
		{
			InitializeComponent ();

            usermn = user;
            admin = adm;
            logged = log;

            App.Baza.CzytajWszystkichUzytkownikow();
        }
	}
}