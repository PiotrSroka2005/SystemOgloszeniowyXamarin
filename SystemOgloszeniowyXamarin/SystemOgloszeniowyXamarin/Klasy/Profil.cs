﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Profil
    {
        [PrimaryKey, AutoIncrement]
        public int ProfilId { get; set; }

        public int UzytkownikId { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Miasto { get; set; }

        public int NumerTelefonu { get; set; }

        public string ZdjecieProfilowe { get; set; }

        public string Stanowisko { get; set; }

        public string PodsumowanieZawodowe { get; set; }

        public Profil(int profilId, int uzytkownikId, string imie, string nazwisko, string miasto, int numerTelefonu, string zdjecieProfilowe, string stanowisko
            , string podsumowanieZawodowe)
        {
            ProfilId = profilId;

            UzytkownikId = uzytkownikId;

            Imie = imie;

            Nazwisko = nazwisko;

            Miasto = miasto;

            NumerTelefonu = numerTelefonu;

            ZdjecieProfilowe = zdjecieProfilowe;

            Stanowisko = stanowisko;

            PodsumowanieZawodowe = podsumowanieZawodowe;
        }


    }
}
