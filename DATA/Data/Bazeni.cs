using System.Collections.Generic;

namespace DATA
{
    public class Bazeni
    {
        public Bazeni()
        {
            Termini = new HashSet<Termini>();
        }

        public int Id { get; set; }
        public string Dimenzije { get; set; }
        public string Naziv { get; set; }
        public string Slika { get; set; }
        public string Opis { get; set; }
        public int GradId { get; set; }
        public virtual Gradovi Grad { get; set; }
        public ICollection<Termini> Termini { get; set; }
    }
}
