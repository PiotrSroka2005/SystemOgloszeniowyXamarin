using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Aplikacja
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string NazwaUzytkownika { get;  set; }
        public string EmailUzytkownika { get;  set; }
        public string TytulOgloszenia { get; set; }
        public int IdOgloszenia { get; set; }

        public Aplikacja(int id, string nazwaUzytkownika, string emailUzytkownika, string tytulOgloszenia, int idOgloszenia)
        {
            Id = id;
            NazwaUzytkownika = nazwaUzytkownika;
            EmailUzytkownika = emailUzytkownika;
            TytulOgloszenia = tytulOgloszenia;
            IdOgloszenia = idOgloszenia;
        }

        public Aplikacja() { }
    }
}
