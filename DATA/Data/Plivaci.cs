using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA
{
    public partial class Plivaci
    {
        public Plivaci()
        {
            Biljeske = new HashSet<Biljeske>();
            PlivaciTermin = new HashSet<PlivaciTermin>();
            TakmicenjaPlivaci = new HashSet<TakmicenjaPlivaci>();
        }
        
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }
        public string Prezime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int? GradId { get; set; }
        public int? GrupaId { get; set; }
        public int NalogId { get; set; }

        public virtual Nalozi Nalog { get; set; }
        public Gradovi Grad { get; set; }
        public Grupe Grupa { get; set; }
        public ICollection<Biljeske> Biljeske { get; set; }
        public ICollection<PlivaciTermin> PlivaciTermin { get; set; }
        public ICollection<TakmicenjaPlivaci> TakmicenjaPlivaci { get; set; }
    }
}
