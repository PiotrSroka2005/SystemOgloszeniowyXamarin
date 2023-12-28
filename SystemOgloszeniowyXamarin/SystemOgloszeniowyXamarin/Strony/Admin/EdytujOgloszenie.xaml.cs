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
	public partial class EdytujOgloszenie : ContentPage
	{
        private List<Kategoria> kategorie;
        private List<Firma> firmy;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        private int _id;
        private DateTime _utowrzenie;

        public EdytujOgloszenie(int ogloszenieId, int kategoriaId, int firmaId, string tytul, string nazwaStanowiska, string poziomStanowiska, string rodzajPracy, string wymiarZatrudnienia, string rodzajUmowy, decimal najmniejszeWynagrodzenie,
        decimal najwiekszeWynagrodzenie, string dniPracy, string godzinyPracy, DateTime dataWaznosci, string obowiazki, string wymagania, string benefity, string informacje, DateTime dataUtworzenia, string zdjecie, int adm, bool log, string user)
		{
			InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            _utowrzenie = dataUtworzenia;
            _id = ogloszenieId;


            kategorie = App.Baza.CzytajKategorie();
            KategoriaComboBox.ItemsSource = kategorie;

            firmy = App.Baza.CzytajFirmy();
            FirmaComboBox.ItemsSource = firmy;


            KategoriaComboBox.Title = "Wybierz kategorię";
            KategoriaComboBox.ItemDisplayBinding = new Binding("KategoriaNazwa");

            FirmaComboBox.Title = "Wybierz firmę";
            FirmaComboBox.ItemDisplayBinding = new Binding("FirmaNazwa");

            TxBTytul.Text = tytul;

            TxBNazwaStanowiska.Text = nazwaStanowiska;

            TxBPoziomStanowiska.Text = poziomStanowiska;

            TxBRodzajPracy.Text = rodzajPracy;

            TxBWymiarZatrudnienia.Text = wymiarZatrudnienia;

            TxBRodzajUmowy.Text = rodzajUmowy;

            TxBNajmniejszeWynagrodzenie.Text = najmniejszeWynagrodzenie.ToString();

            TxBNajwiekszeWynagrodzenie.Text = najwiekszeWynagrodzenie.ToString();

            TxBDniPracy.Text = dniPracy;

            TxBGodzinyPracy.Text = godzinyPracy;

            TxBDataWaznosci.Date = dataWaznosci;

            TxBObowiazki.Text = obowiazki;

            TxBWymagania.Text = wymagania;

            TxBBenefity.Text = benefity;

            TxBInformacje.Text = informacje;

            TxBZdjecie.Text = zdjecie;

            DateTime DataUtworzeniaOgloszenia = dataUtworzenia;
        }

        private void Edytuj_Click(object sender, EventArgs e)
        {

            Kategoria wybranaKategoria = (Kategoria)KategoriaComboBox.SelectedItem;

            Firma wybranaFirma = (Firma)FirmaComboBox.SelectedItem;

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

            string Zdjecie = TxBZdjecie.Text;

            DateTime DataUtworzenia = _utowrzenie.Date;

            if (DataWaznosci == null)
            {
                DisplayAlert("Podaj datę ważności.", "Product Error", "OK");              
            }

            decimal NajmniejszeWynagrodzenie=0;
            decimal NajwiekszeWynagrodzenie=0;
            if (Regex.IsMatch(NajmniejszeWynagrodzenieText, @"^[-,0-9]+$"))
            {
                NajmniejszeWynagrodzenie = decimal.Parse(NajmniejszeWynagrodzenieText);
            }
            else
            {
                DisplayAlert("Mozna wprowadzac wartosc dziesietne tylko po przecinku.", "Product Error", "OK");
                return;
            }

            if (Regex.IsMatch(NajwiekszeWynagrodzenieText, @"^[-,0-9]+$"))
            {
                NajwiekszeWynagrodzenie = decimal.Parse(NajwiekszeWynagrodzenieText);
            }
            else
            {
                DisplayAlert("Mozna wprowadzac wartosc dziesietne tylko po przecinku.", "Product Error", "OK");
            }

            if (!(string.IsNullOrWhiteSpace(TxBTytul.Text) || string.IsNullOrWhiteSpace(TxBNazwaStanowiska.Text) || string.IsNullOrWhiteSpace(TxBRodzajPracy.Text) || string.IsNullOrWhiteSpace(TxBWymiarZatrudnienia.Text) ||
            string.IsNullOrWhiteSpace(TxBRodzajUmowy.Text) || string.IsNullOrWhiteSpace(TxBTytul.Text) || string.IsNullOrWhiteSpace(TxBNajmniejszeWynagrodzenie.Text) || string.IsNullOrWhiteSpace(TxBNajwiekszeWynagrodzenie.Text) || string.IsNullOrWhiteSpace(TxBDniPracy.Text) ||
            string.IsNullOrWhiteSpace(TxBGodzinyPracy.Text) || string.IsNullOrWhiteSpace(TxBDataWaznosci.Date.ToString()) || string.IsNullOrWhiteSpace(TxBObowiazki.Text) || string.IsNullOrWhiteSpace(TxBWymagania.Text) || string.IsNullOrWhiteSpace(TxBBenefity.Text) || string.IsNullOrWhiteSpace(TxBInformacje.Text) || string.IsNullOrWhiteSpace(TxBZdjecie.Text)))
            {
                if (wybranaKategoria != null)
                {
                    if (wybranaFirma != null)
                    {
                        int id = _id;
                        int kategoria = wybranaKategoria.KategoriaId;
                        int firma = wybranaFirma.FirmaId;

                        Ogloszenie oglo = new Ogloszenie();
                        oglo.KategoriaId = kategoria;
                        oglo.FirmaId = firma;
                        oglo.Tytul = Tytul;
                        oglo.NazwaStanowiska = NazwaStanowiska;
                        oglo.PoziomStanowiska = PoziomStanowiska;
                        oglo.RodzajPracy = RodzajPracy;
                        oglo.WymiarZatrudnienia = WymiarZatrudnienia;
                        oglo.RodzajUmowy = RodzajUmowy;
                        oglo.NajmniejszeWynagrodzenie = NajmniejszeWynagrodzenie;
                        oglo.NajwiekszeWynagrodzenie = NajwiekszeWynagrodzenie;
                        oglo.DniPracy = DniPracy;
                        oglo.GodzinyPracy = GodzinyPracy;
                        oglo.OgloszenieId = id;
                        oglo.DataWaznosci = DataWaznosci;
                        oglo.Obowiazki = Obowiazki;
                        oglo.Wymagania = Wymagania;
                        oglo.Benefity = Benefity;
                        oglo.Informacje = Informacje;
                        oglo.DataUtworzenia = DataUtworzenia;
                        oglo.Zdjecie = Zdjecie;
                        oglo.AktualizujNazweFirmy();
                        App.Baza.AktualizujOgloszenie(oglo);                        
                        DisplayAlert("Ogłoszenie zostało zaktualizowane", "Info", "OK");
                    }
                }
            }
            else
            {
                DisplayAlert("Proszę uzupełnic pola", "Info", "OK");
            }
        }


        private void ZarzadzajOgloszeniami(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ZarzadzanieOgloszeniami(admin, logged, usermn));
        }
    }
}