using System;
using System.Collections.Generic;

namespace DATA
{
    public class TakmicenjaPlivaci
    {
        public int Id { get; set; }
        public int TakmicenjeId { get; set; }
        public int PlivacId { get; set; }

        public Plivaci Plivac { get; set; }
        public Takmicenja Takmicenje { get; set; }
    }
}
