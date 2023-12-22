using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Kategoria
    {
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
