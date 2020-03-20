using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA
{
    public class Nalozi
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsRekreativac { get; set; }
        public bool IsTrener { get; set; }
        public bool IsPlivac { get; set; }
        public bool Aktivan { get; set; }
    }
}
