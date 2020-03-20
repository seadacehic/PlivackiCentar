using DATA;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DATA
{
    public partial class dataContext : DbContext
    {
        public dataContext()
           : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Administratori> Administratori { get; set; }
        public virtual DbSet<Bazeni> Bazeni { get; set; }
        public virtual DbSet<Biljeske> Biljeske { get; set; }
        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Grupe> Grupe { get; set; }
        public virtual DbSet<Izvjestaji> Izvjestaji { get; set; }
        public virtual DbSet<Plivaci> Plivaci { get; set; }
        public virtual DbSet<PlivaciTermin> PlivaciTermin { get; set; }
        public virtual DbSet<Rekreativci> Rekreativci { get; set; }
        public virtual DbSet<RekreativciTermin> RekreativciTermin { get; set; }
        public virtual DbSet<Takmicenja> Takmicenja { get; set; }
        public virtual DbSet<Termini> Termin { get; set; }
        public virtual DbSet<Treneri> Treneri { get; set; }
        public virtual DbSet<TakmicenjaPlivaci> TakmicenjaPlivaci { get; set; }
        public virtual DbSet<Nalozi> Nalozi { get; set; }
    }
}
