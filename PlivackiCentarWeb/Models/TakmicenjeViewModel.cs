using DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlivackiCentarWeb.Models
{
    public class TakmicenjeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje Naziv je obavezno polje.")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje Datum je obavezno polje.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Unesite datum u formatu dd/MM/yyyy")]
        public DateTime? Datum { get; set; }
        [Required(ErrorMessage = "Polje Osvojena mjesta je obavezno polje.")]
        public string OsvojenaMjesta { get; set; }

        [Required(ErrorMessage = "Polje Grad je obavezno polje.")]
        public int GradId { get; set; }
        public string Grad { get; set; }

        public List<DATA.Gradovi> Gradovi { get; set; }

    }

    public class TakmicenjePlivacViewModel
    {
        [Required(ErrorMessage = "Polje Takmicenje je obavezno polje.")]
        public int TakmicenjeId { get; set; }

        [Required(ErrorMessage = "Polje Plivac je obavezno polje.")]
        public int PlivacId { get; set; }

        public List<TakmicenjeViewModel> SvaTakmicenja { get; set; }
        public List<TakmicenjeViewModel> TakmicenjaKlijenta { get; set; }

    }
}