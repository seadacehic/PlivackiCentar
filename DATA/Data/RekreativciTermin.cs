using System;
using System.Collections.Generic;

namespace DATA
{
    public class RekreativciTermin
    {
        public int Id { get; set; }
        public int RekreativacId { get; set; }
        public int TerminId { get; set; }

        public Rekreativci Rekreativac { get; set; }
        public Termini Termin { get; set; }
    }
}
