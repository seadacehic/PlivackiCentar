using System;
using System.Collections.Generic;

namespace DATA
{
    public partial class Drzave
    {
        public Drzave()
        {
            Gradovi = new HashSet<Gradovi>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Gradovi> Gradovi { get; set; }
    }
}
