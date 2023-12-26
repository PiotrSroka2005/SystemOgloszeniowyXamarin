using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using SystemOgloszeniowyXamarin.Klasy;

namespace SystemOgloszeniowyXamarin
{
    public partial class App : Application
    {

        static Baza baza;

        public static Baza Baza
        {
            get
            {
                if (baza == null)
                {
                    baza = new Baza(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "systemOgloszeniowy.db3"));
                }
                return baza;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
