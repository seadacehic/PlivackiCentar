using DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlivackiCentarWeb.Models
{
    public class KlijentViewModel
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }

        [Required(ErrorMessage = "Polje Ime je obavezno polje.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje Prezime je obavezno polje.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Polje Email je obavezno polje.")]
        [EmailAddress(ErrorMessage = "Polje Email nije validna email adresa.")]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Spol { get; set; }

        [Required(ErrorMessage = "Polje Datum rođenja je obavezno polje.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Unesite datum u formatu dd/MM/yyyy")]
        public DateTime? DatumRodjenja { get; set; }
        public bool IsRekreativac { get; set; }
        public bool IsPlivac { get; set; }
    }

    public class KlijentPreviewViewModel
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public bool IsPlivac { get; set; }
        public bool IsRekreativac { get; set; }

        public List<TerminViewModel> Termini { get; set; }
    }
    public class TrenerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje Ime je obavezno polje.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje Prezime je obavezno polje.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Polje Email je obavezno polje.")]
        [EmailAddress]
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Spol { get; set; }
        public string Zvanje { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Polje Email je obavezno polje.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email adresa nije validna.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje Lozinka je obavezno polje.")]
        [DataType(DataType.Password, ErrorMessage = "")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Polje Ime je obavezno polje.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Polje Prezime je obavezno polje.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Polje Email je obavezno polje.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje Lozinka je obavezno polje.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Polje Potvrda lozinke je obavezno polje.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }
    }

}
