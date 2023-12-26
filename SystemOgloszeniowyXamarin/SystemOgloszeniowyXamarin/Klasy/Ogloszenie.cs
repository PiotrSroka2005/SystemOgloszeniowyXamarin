using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Ogloszenie
    {

        [PrimaryKey, AutoIncrement]
        public int OgloszenieId { get; set; }

        public string Tytul { get; set; }

        public string NazwaStanowiska { get; set; }

        public string PoziomStanowiska { get; set; }

        public string RodzajPracy { get; set; }

        public string WymiarZatrudnienia { get; set; }

        public int KategoriaId { get; set; }

        public int FirmaId { get; set; }

        public string NazwaFirmy { get; set; }

        public string RodzajUmowy { get; set; }

        public decimal NajmniejszeWynagrodzenie { get; set; }

        public decimal NajwiekszeWynagrodzenie { get; set; }

        public string DniPracy { get; set; }

        public string GodzinyPracy { get; set; }

        public DateTime DataWaznosci { get; set; }

        public string Obowiazki { get; set; }

        public string Wymagania { get; set; }

        public string Benefity { get; set; }

        public string Informacje { get; set; }

        public DateTime DataUtworzenia { get; set; }

        public string Zdjecie { get; set; }

        public Ogloszenie(int ogloszenieId, int kategoriaId, int firmaId, string tytul, string nazwaStanowiska, string poziomStanowiska, string rodzajPracy, string wymiarZatrudnienia, string rodzajUmowy, decimal najmniejszeWynagrodzenie,
        decimal najwiekszeWynagrodzenie, string dniPracy, string godzinyPracy, DateTime dataWaznosci, string obowiazki, string wymagania, string benefity, string informacje, DateTime dataUtworzenia, string zdjecie)
        {
            OgloszenieId = ogloszenieId;
            KategoriaId = kategoriaId;
            FirmaId = firmaId;
            Tytul = tytul;
            NazwaStanowiska = nazwaStanowiska;
            PoziomStanowiska = poziomStanowiska;
            RodzajPracy = rodzajPracy;
            WymiarZatrudnienia = wymiarZatrudnienia;
            RodzajUmowy = rodzajUmowy;
            NajmniejszeWynagrodzenie = najmniejszeWynagrodzenie;
            NajwiekszeWynagrodzenie = najwiekszeWynagrodzenie;
            DniPracy = dniPracy;
            GodzinyPracy = godzinyPracy;
            DataWaznosci = dataWaznosci;
            Obowiazki = obowiazki;
            Wymagania = wymagania;
            Benefity = benefity;
            Informacje = informacje;
            DataUtworzenia = dataUtworzenia;
            Zdjecie = zdjecie;
            AktualizujNazweFirmy();
        }

        public Firma PobierzDaneOFirmie(int firmaId)
        {
            Firma firma = null;

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SQLiteConnection($"Filename={dbPath}"))
            {
                firma = db.Table<Firma>().FirstOrDefault(f => f.FirmaId == firmaId);
            }

            return firma;
        }

        public void AktualizujNazweFirmy()
        {
            var firma = PobierzDaneOFirmie(FirmaId);
            NazwaFirmy = firma != null ? firma.FirmaNazwa : string.Empty;
        }

        public Ogloszenie() { }

    }
}
