using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA
{
    public partial class Rekreativci
    {
        public Rekreativci()
        {
            RekreativciTermini = new HashSet<RekreativciTermin>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int? GradId { get; set; }
        public int NalogId { get; set; }

        public virtual Nalozi Nalog { get; set; }
        public Gradovi Grad { get; set; }
        public ICollection<RekreativciTermin> RekreativciTermini { get; set; }
    }
}
