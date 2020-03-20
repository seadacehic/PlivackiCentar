using System;
using System.Collections.Generic;

namespace DATA
{
    public partial class Grupe
    {
        public Grupe()
        {
            Plivaci = new HashSet<Plivaci>();
            Termini = new HashSet<Termini>();
        }
        public int Id { get; set; }
        public string Uzrast { get; set; }
        public string Vrsta { get; set; }

        public ICollection<Plivaci> Plivaci { get; set; }
        public ICollection<Termini> Termini { get; set; }
    }
}
