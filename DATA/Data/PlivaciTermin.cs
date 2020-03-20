using System;
using System.Collections.Generic;

namespace DATA
{
    public class PlivaciTermin
    {
        public int Id { get; set; }
        public int PlivaciId { get; set; }
        public int TerminId { get; set; }

        public Plivaci Plivac { get; set; }
        public Termini Termin { get; set; }
    }
}
