using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemOgloszeniowyXamarin.Klasy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOgloszeniowyXamarin.Strony.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DodajOgloszenie : ContentPage
	{
        private List<Kategoria> kategorie;
        private List<Firma> firmy;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        public DodajOgloszenie(int adm, bool log, string user)
		{
			InitializeComponent ();

            kategorie = App.Baza.CzytajKategorie();
            KategoriaComboBox.ItemsSource = kategorie;

            firmy = App.Baza.CzytajFirmy();
            FirmaComboBox.ItemsSource = firmy;


            KategoriaComboBox.Title = "Wybierz kategorię";
            KategoriaComboBox.ItemDisplayBinding = new Binding("KategoriaNazwa");

            FirmaComboBox.Title = "Wybierz firmę";
            FirmaComboBox.ItemDisplayBinding = new Binding("FirmaNazwa");

            usermn = user;
            admin = adm;
            logged = log;
        }

        private void ZarzadzajOgloszeniami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ZarzadzanieOgloszeniami(admin, logged, usermn));
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            var kategoria = KategoriaComboBox.SelectedItem as Kategoria;

            var firma = FirmaComboBox.SelectedItem as Firma;

            int Id = 0;

            int KategoriaId = kategoria.KategoriaId;

            int FirmaId = firma.FirmaId;

            string Tytul = TxBTytul.Text;

            string NazwaStanowiska = TxBNazwaStanowiska.Text;

            string PoziomStanowiska = TxBPoziomStanowiska.Text;

            string RodzajPracy = TxBRodzajPracy.Text;

            string WymiarZatrudnienia = TxBWymiarZatrudnienia.Text;

            string RodzajUmowy = TxBRodzajUmowy.Text;

            string NajmniejszeWynagrodzenieText = TxBNajmniejszeWynagrodzenie.Text;

            string NajwiekszeWynagrodzenieText = TxBNajwiekszeWynagrodzenie.Text;

            string DniPracy = TxBDniPracy.Text;

            string GodzinyPracy = TxBGodzinyPracy.Text;

            DateTime DataWaznosci = TxBDataWaznosci.Date;

            string Obowiazki = TxBObowiazki.Text;

            string Wymagania = TxBWymagania.Text;

            string Benefity = TxBBenefity.Text;

            string Informacje = TxBInformacje.Text;

            DateTime DataUtworzenia = DateTime.Now;

            string Zdjecie = TxBZdjecie.Text;

            if (DataWaznosci == null)
            {
                DisplayAlert("Podaj datę ważności.", "Product Error", "OK");
            }

            decimal NajmniejszeWynagrodzenie = 0;
            decimal NajwiekszeWynagrodzenie = 0;
            if (Regex.IsMatch(NajmniejszeWynagrodzenieText, @"^[-,0-9]+$"))
            {
                NajmniejszeWynagrodzenie = decimal.Parse(NajmniejszeWynagrodzenieText);
            }
            else
            {
                DisplayAlert("Mozna wprowadzac wartosc dziesietne tylko po przecinku.", "Product Error", "OK");
            }

            if (Regex.IsMatch(NajwiekszeWynagrodzenieText, @"^[-,0-9]+$"))
            {
                NajwiekszeWynagrodzenie = decimal.Parse(NajwiekszeWynagrodzenieText);
            }
            else
            {
                DisplayAlert("Mozna wprowadzac wartosc dziesietne tylko po przecinku.", "Product Error", "OK");                
            }

            Ogloszenie ogloszenie = new Ogloszenie(Id, KategoriaId, FirmaId, Tytul, NazwaStanowiska, PoziomStanowiska, RodzajPracy, WymiarZatrudnienia, RodzajUmowy, NajmniejszeWynagrodzenie, NajwiekszeWynagrodzenie, DniPracy, GodzinyPracy, DataWaznosci, Obowiazki, Wymagania, Benefity, Informacje, DataUtworzenia, Zdjecie);

            App.Baza.DodajOgloszenie(ogloszenie);

            TxBTytul.Text = string.Empty;

            TxBNazwaStanowiska.Text = string.Empty;

            TxBPoziomStanowiska.Text = string.Empty;

            TxBRodzajPracy.Text = string.Empty;

            TxBWymiarZatrudnienia.Text = string.Empty;

            TxBRodzajUmowy.Text = string.Empty;

            TxBNajmniejszeWynagrodzenie.Text = string.Empty;

            TxBNajwiekszeWynagrodzenie.Text = string.Empty;

            TxBDniPracy.Text = string.Empty;

            TxBGodzinyPracy.Text = string.Empty;

            TxBDataWaznosci.Date = DateTime.Now;

            TxBObowiazki.Text = string.Empty;

            TxBWymagania.Text = string.Empty;

            TxBBenefity.Text = string.Empty;

            TxBInformacje.Text = string.Empty;

            TxBZdjecie.Text = string.Empty;

            KategoriaComboBox.SelectedIndex = 1;
            FirmaComboBox.SelectedIndex = 1;
        }
    }
}