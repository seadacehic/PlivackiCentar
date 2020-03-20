using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATA
{
    public partial class Takmicenja
    {

        public int Id { get; set; }
        public string Naziv { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Datum { get; set; }
        public string OsvojenaMjesta { get; set; }
        public int GradId { get; set; }

        public virtual Gradovi Grad { get; set; }
    }
}
