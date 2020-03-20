using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA
{
    public partial class Treneri
    {
        public Treneri()
        {
            Termini = new HashSet<Termini>();
        }
        
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Kontakt { get; set; }
        public string Email { get; set; }
        public string Zvanje { get; set; }
        public int? GradId { get; set; }
        public Gradovi Grad { get; set; }
        public int NalogId { get; set; }
        public virtual Nalozi Nalog { get; set; }
        public ICollection<Termini> Termini { get; set; }


        //public int PlataId { get; set; }
        //public ICollection<Plata> Plata { get; set; }

    }
}
