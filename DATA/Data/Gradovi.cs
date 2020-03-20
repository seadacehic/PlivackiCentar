using System;
using System.Collections.Generic;

namespace DATA
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Administratori = new HashSet<Administratori>();
            Bazeni = new HashSet<Bazeni>();
            Plivaci = new HashSet<Plivaci>();
            Rekreativci = new HashSet<Rekreativci>();
            Takmičenja = new HashSet<Takmicenja>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public Drzave Drzava { get; set; }
        public ICollection<Administratori> Administratori { get; set; }
        public ICollection<Bazeni> Bazeni { get; set; }
        public ICollection<Plivaci> Plivaci { get; set; }
        public ICollection<Rekreativci> Rekreativci { get; set; }
        public ICollection<Takmicenja> Takmičenja { get; set; }
    }
}
