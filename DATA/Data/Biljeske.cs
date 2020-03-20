using System;
using System.Collections.Generic;

namespace DATA
{
    public partial class Biljeske
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public int TerminId { get; set; }
        public int PlivacId { get; set; }

        public Plivaci Plivac { get; set; }
        public Termini Termin { get; set; }
    }
}
