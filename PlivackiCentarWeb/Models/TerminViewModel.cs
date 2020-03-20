using DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlivackiCentarWeb.Models
{
    public class TerminViewModel
    {
        public int Id { get; set; }
        public string VrijemeOd { get; set; }
        public string VrijemeDo { get; set; }

        [Required(ErrorMessage = "Polje Datum je obavezno polje.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Unesite datum u formatu dd/MM/yyyy")]
        public DateTime? Datum { get; set; }

        public int TrenerId { get; set; }
        public Treneri Trener { get; set; }
        public List<TrenerViewModel> Treneri { get; set; }
        public int GrupaId { get; set; }
        public Grupe Grupa { get; set; }
        public List<GrupaViewModel> Grupe { get; set; }
        public int BazenId { get; set; }
        public Bazeni Bazen { get; set; }
        public List<BazenViewModel> Bazeni { get; set; }


    }
    
}