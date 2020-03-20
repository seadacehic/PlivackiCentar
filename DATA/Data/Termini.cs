using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA
{
    public class Termini
    {
        public Termini()
        {
            Biljeske = new HashSet<Biljeske>();
            PlivaciTermini = new HashSet<PlivaciTermin>();
            RekreativciTermini = new HashSet<RekreativciTermin>();
        }

        public int Id { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Datum { get; set; }

        public string VrijemeOd { get; set; }
        public string VrijemeDo { get; set; }
        public int? BazenId { get; set; }
        public int TrenerId { get; set; }
        public int GrupaId { get; set; }

        public Bazeni Bazen { get; set; }
        public Grupe Grupa { get; set; }
        public Treneri Trener { get; set; }
        public ICollection<Biljeske> Biljeske { get; set; }
        public ICollection<PlivaciTermin> PlivaciTermini { get; set; }
        public ICollection<RekreativciTermin> RekreativciTermini { get; set; }
    }
}
