using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemOgloszeniowyXamarin.Klasy
{
    public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int FirmaId { get; set; }
        public string FirmaNazwa { get; set; }

        public Firma() { }

        public Firma(int FirmaId, string FirmaNazwa)
        {
            this.FirmaId = FirmaId;
            this.FirmaNazwa = FirmaNazwa;
        }
    }
}
