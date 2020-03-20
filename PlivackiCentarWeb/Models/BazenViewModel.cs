using DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlivackiCentarWeb.Models
{
    public class BazenViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje Dimenzije je obavezno polje.")]
        public string Dimenzije { get; set; }

        [Required(ErrorMessage = "Polje Naziv je obavezno polje.")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje Opis je obavezno polje.")]
        public string Opis { get; set; }
        public string SlikaUrl { get; set; }
        public HttpPostedFileBase Slika { get; set; }

        public int GradId { get; set; }
        public string Grad { get; set; }
        public List<Gradovi> Gradovi{ get; set; }

    }
}