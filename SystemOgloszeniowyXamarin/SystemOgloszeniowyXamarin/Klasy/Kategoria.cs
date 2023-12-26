using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Kategoria
    {
        [PrimaryKey, AutoIncrement]
        public int KategoriaId { get; set; }
        public string KategoriaNazwa { get; set; }

        public Kategoria() { }

        public Kategoria(int KategoriaId, string KategoriaNazwa)
        {
            this.KategoriaId = KategoriaId;
            this.KategoriaNazwa = KategoriaNazwa;
        }
    }
}
