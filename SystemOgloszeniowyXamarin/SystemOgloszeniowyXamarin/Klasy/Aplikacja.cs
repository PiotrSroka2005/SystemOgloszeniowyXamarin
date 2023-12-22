using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Aplikacja
    {
        public string NazwaUzytkownika { get; private set; }
        public string EmailUzytkownika { get; private set; }
        public string TytulOgloszenia { get; private set; }
        public int IdOgloszenia { get; private set; }

        public Aplikacja(string nazwaUzytkownika, string emailUzytkownika, string tytulOgloszenia, int idOgloszenia)
        {
            NazwaUzytkownika = nazwaUzytkownika;
            EmailUzytkownika = emailUzytkownika;
            TytulOgloszenia = tytulOgloszenia;
            IdOgloszenia = idOgloszenia;
        }
    }
}
