using System;
using System.Collections.Generic;

namespace DATA
{
    public partial class Izvjestaji
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime? Datum { get; set; }
        public string Opis { get; set; }
        public int AdministratorId { get; set; }
        public Administratori Administrator { get; set; }
    }
}
