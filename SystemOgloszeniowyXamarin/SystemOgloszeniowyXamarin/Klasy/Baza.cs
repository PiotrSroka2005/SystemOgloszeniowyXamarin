using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Baza
    {
        readonly SQLiteConnection _database;

        public Baza(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);          
        }

        public void UtworzUzytkownikow()
        {
            _database.CreateTable<Uzytkownik>();
        }


        public bool CzyIstniejeEmail(string email)
        {
            using (var db = new SQLiteConnection(_database.DatabasePath))
            {
                var count = db.Table<Uzytkownik>().Count(u => u.Email == email);
                return count > 0;
            }
        }

        public bool CzyIstniejeUzytkownik(string username)
        {
            using (var db = new SQLiteConnection(_database.DatabasePath))
            {
                var count = db.Table<Uzytkownik>().Count(u => u.Nick == username);
                return count > 0;
            }
        }


        public bool IsUsernameExistsInDatabase(string username)
        {
            using (var db = new SQLiteConnection(_database.DatabasePath))
            {
                var user = db.Table<Uzytkownik>().FirstOrDefault(u => u.Nick == username);
                return user != null;
            }
        }

        public bool IsPasswordCorrect(string password)
        {
            using (var db = new SQLiteConnection(_database.DatabasePath))
            {
                var user = db.Table<Uzytkownik>().FirstOrDefault(u => u.Haslo == password);
                return user != null;
            }
        }

        public bool IsAdmin(string username)
        {
            using (var db = new SQLiteConnection(_database.DatabasePath))
            {
                var user = db.Table<Uzytkownik>().FirstOrDefault(u => u.Nick == username && u.Administrator);
                return user != null;
            }
        }

        public List<Uzytkownik> CzytajWszystkichUzytkownikow()
        {
            return _database.Table<Uzytkownik>().ToList();
        }

        public List<Ogloszenie> CzytajWszystkieOgloszenia()
        {
            return _database.Table<Ogloszenie>().ToList();
        }

        public int DodajLubAktualizujUzytkownika(Uzytkownik uzytkownik)
        {
            if (uzytkownik.ID != 0)
            {
                return _database.Update(uzytkownik);
            }
            else
            {
                return _database.Insert(uzytkownik);
            }
        }

        public Uzytkownik CzytajUzytkownikaPoNicku(string nick)
        {
            return _database.Table<Uzytkownik>().Where(u => u.Nick == nick).FirstOrDefault();
        }

        public int NadajUzytkownikowiAdmina(Uzytkownik uzytkownik)
        {
            return _database.Update(uzytkownik);
        }

        //public void UtworzTabeleProfile(string user)
        //{
        //    var uzytkownik = _database.Table<Uzytkownik>().Where(u => u.Nick == user).FirstOrDefault();
        //    if (uzytkownik != null)
        //    {
        //        var profile = new Profil { UzytkownikId = uzytkownik.ID };
        //        _database.Insert(profile);

        //        // Tworzenie pozostałych tabel i relacji
        //        // ...
        //    }
        //}

        //public List<Profil> CzytajProfile(string user)
        //{
        //    var uzytkownik = _database.Table<Uzytkownik>().Where(u => u.Nick == user).FirstOrDefault();
        //    if (uzytkownik != null)
        //    {
        //        return _database.Table<Profil>().Where(p => p.UzytkownikId == uzytkownik.Id).ToList();
        //    }
        //    return new List<Profil>();
        //}

        public void UtworzTabeleOgloszenia()
        {
            _database.CreateTable<Kategoria>();
            _database.CreateTable<Firma>();
            _database.CreateTable<Ogloszenie>();
        }

        public int DodajOgloszenie(Ogloszenie ogloszenie)
        {
            return _database.Insert(ogloszenie);
        }

        public int AktualizujOgloszenie(Ogloszenie ogloszenie)
        {
            return _database.Update(ogloszenie);
        }

        public List<Ogloszenie> CzytajOgloszenia(int kategoriaId, int firmaId)
        {
            return _database.Table<Ogloszenie>().Where(o => o.KategoriaId == kategoriaId && o.FirmaId == firmaId).ToList();
        }

        public List<Ogloszenie> CzytajSzczegolyOgloszenia(int IdWybranego)
        {
            return _database.Table<Ogloszenie>().Where(o => o.OgloszenieId == IdWybranego).ToList();
        }

        public void UsunOgloszenie(Ogloszenie ogloszenie)
        {
            _database.Delete(ogloszenie);
        }

        public void UsunKategorie(Kategoria kategoria)
        {
            _database.Table<Ogloszenie>().Delete(o => o.KategoriaId == kategoria.KategoriaId);
            _database.Delete(kategoria);
        }

        public void UtworzTabeleKategorie()
        {
            _database.CreateTable<Kategoria>();
        }

        public void DodajKategorie(Kategoria kategoria)
        {
            _database.Insert(kategoria);
        }

        public void AktualizujKategorie(Kategoria kategoria)
        {
            _database.Update(kategoria);
        }

        public List<Kategoria> CzytajKategorie()
        {
            return _database.Table<Kategoria>().ToList();
        }

        public List<Firma> CzytajFirmy()
        {
            return _database.Table<Firma>().ToList();
        }

        public void UsunFirme(Firma firma)
        {
            _database.Table<Ogloszenie>().Delete(o => o.FirmaId == firma.FirmaId);
            _database.Delete(firma);
        }

       
        public void UtworzTabeleFirmy()
        {
            _database.CreateTable<Firma>();
        }

        public void DodajFirme(Firma firma)
        {
            _database.Insert(firma);
        }

        public void AktualizujFirme(Firma firma)
        {
            _database.Update(firma);
        }

        public void UtworzTabeleAplikacje()
        {
            _database.CreateTable<Aplikacja>();
        }

        public void DodajAplikacje(string nazwaUzytkownika, string emailUzytkownika, string tytulOgloszenia, int idOgloszenia)
        {
            var aplikacja = new Aplikacja
            {
                NazwaUzytkownika = nazwaUzytkownika,
                EmailUzytkownika = emailUzytkownika,
                TytulOgloszenia = tytulOgloszenia,
                IdOgloszenia = idOgloszenia
            };
            _database.Insert(aplikacja);
        }

        public List<Aplikacja> PobierzAplikacjeUzytkownika(string nazwaUzytkownika)
        {
            return _database.Table<Aplikacja>().Where(a => a.NazwaUzytkownika == nazwaUzytkownika).ToList();
        }

        public bool CzyUzytkownikAplikowal(string nazwaUzytkownika, int idOgloszenia)
        {
            var count = _database.Table<Aplikacja>().Count(a => a.NazwaUzytkownika == nazwaUzytkownika && a.IdOgloszenia == idOgloszenia);
            return count > 0;
        }


        public void UsunAplikacje(int idOgloszenia, string nazwaUzytkownika)
        {
            var aplikacjeToDelete = _database.Table<Aplikacja>().Where(a => a.IdOgloszenia == idOgloszenia && a.NazwaUzytkownika == nazwaUzytkownika).ToList();

            foreach (var aplikacja in aplikacjeToDelete)
            {
                _database.Delete(aplikacja);
            }
        }

        public Firma PobierzDaneOFirmie(int firmaId)
        {
            Firma firma = null;

            using (var db = new SQLiteConnection(_database.DatabasePath))
            {
                firma = db.Table<Firma>().FirstOrDefault(f => f.FirmaId == firmaId);
            }

            return firma;
        }
       
        public List<Ogloszenie> CzytajWyszukaneOgloszeniaKategoria(int wybranaKategoria)
        {
            return _database.Table<Ogloszenie>().Where(o => o.KategoriaId == wybranaKategoria).OrderByDescending(o => o.DataUtworzenia).ToList();
        }

        public List<Ogloszenie> CzytajWyszukaneOgloszenia(string szukana, int wybranaKategoria)
        {
            var query = _database.Table<Ogloszenie>().OrderByDescending(o => o.DataUtworzenia);

            if (!string.IsNullOrEmpty(szukana))
            {
                query = query.Where(o => o.Tytul.Contains(szukana) || o.NazwaStanowiska.Contains(szukana) || o.NazwaFirmy.Contains(szukana));
            }

            if (wybranaKategoria > 0)
            {
                query = query.Where(o => o.KategoriaId == wybranaKategoria);
            }

            return query.ToList();
        }

        public List<Ogloszenie> CzytajWyszukaneOgloszeniaSzukana(string szukana)
        {
            var query = _database.Table<Ogloszenie>().OrderByDescending(o => o.DataUtworzenia);

            if (!string.IsNullOrEmpty(szukana))
            {                
                query = query.Where(o =>
                    o.Tytul.Contains(szukana) ||
                    o.NazwaStanowiska.Contains(szukana) ||
                    o.NazwaFirmy.Contains(szukana)
                );
            }

            return query.ToList();
        }


        public Uzytkownik PobierzUzytkownika(string nick)
        {
            return _database.Table<Uzytkownik>().FirstOrDefault(u => u.Nick == nick);
        }



    }
}
