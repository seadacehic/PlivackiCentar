using DATA;
using System;
using System.Collections.Generic;

namespace DATA
{
    public partial class Administratori
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? GradId { get; set; }
        public Gradovi Grad { get; set; }
        public int NalogId { get; set; }
        public virtual Nalozi Nalog { get; set; }
    }
}
