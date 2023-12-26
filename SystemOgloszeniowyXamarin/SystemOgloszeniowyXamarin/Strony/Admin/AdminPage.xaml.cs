using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Strony;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPage : ContentPage
	{
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public AdminPage(int adm, bool log, string user)
		{
			InitializeComponent ();

            usermn = user;
            admin = adm;
            logged = log;
        }
        
       
        private void StronaGlowna(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(admin, logged, usermn));
        }

        private void ZarzadzajKategoriami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(admin, logged, usermn));
        }

        private void ZarzadzajFirmami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(admin, logged, usermn));
        }

        private void ZarzadzajOgloszeniami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(admin, logged, usermn));
        }

        private void giveAdmin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(admin, logged, usermn));
        }
    }
}