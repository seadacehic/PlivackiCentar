using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlivackiCentarWeb.Models
{
    public class GrupaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje Uzrast je obavezno polje.")]
        public string Uzrast { get; set; }

        [Required(ErrorMessage = "Polje Vrsta je obavezno polje.")]
        public string Vrsta { get; set; }
        public int BrojKlijenata { get; set; }

    }
}