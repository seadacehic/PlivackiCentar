namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administratori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        GradId = c.Int(nullable: false),
                        NalogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradovi", t => t.GradId, cascadeDelete: false)
                .ForeignKey("dbo.Nalozi", t => t.NalogId, cascadeDelete: false)
                .Index(t => t.GradId)
                .Index(t => t.NalogId);
            
            CreateTable(
                "dbo.Gradovi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        DrzavaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drzave", t => t.DrzavaId, cascadeDelete: false)
                .Index(t => t.DrzavaId);
            
            CreateTable(
                "dbo.Bazeni",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dimenzije = c.String(),
                        Naziv = c.String(),
                        Opis = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradovi", t => t.GradId, cascadeDelete: false)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Termini",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(),
                        VrijemeOd = c.DateTime(),
                        VrijemeDo = c.DateTime(),
                        BazenId = c.Int(),
                        TrenerId = c.Int(nullable: false),
                        GrupaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bazeni", t => t.BazenId)
                .ForeignKey("dbo.Grupe", t => t.GrupaId, cascadeDelete: false)
                .ForeignKey("dbo.Treneri", t => t.TrenerId, cascadeDelete: false)
                .Index(t => t.BazenId)
                .Index(t => t.TrenerId)
                .Index(t => t.GrupaId);
            
            CreateTable(
                "dbo.Biljeske",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        TerminId = c.Int(nullable: false),
                        PlivacId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plivaci", t => t.PlivacId, cascadeDelete: false)
                .ForeignKey("dbo.Termini", t => t.TerminId, cascadeDelete: false)
                .Index(t => t.TerminId)
                .Index(t => t.PlivacId);
            
            CreateTable(
                "dbo.Plivaci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Spol = c.String(),
                        Kontakt = c.String(),
                        GradId = c.Int(nullable: false),
                        GrupaId = c.Int(nullable: false),
                        NalogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradovi", t => t.GradId, cascadeDelete: false)
                .ForeignKey("dbo.Grupe", t => t.GrupaId, cascadeDelete: false)
                .ForeignKey("dbo.Nalozi", t => t.NalogId, cascadeDelete: false)
                .Index(t => t.GradId)
                .Index(t => t.GrupaId)
                .Index(t => t.NalogId);
            
            CreateTable(
                "dbo.Grupe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uzrast = c.String(),
                        Vrsta = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nalozi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KorisnikId = c.Int(nullable: false),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                        Email = c.String(),
                        IsAdministrator = c.Boolean(nullable: false),
                        IsRekreativac = c.Boolean(nullable: false),
                        IsTrener = c.Boolean(nullable: false),
                        IsPlivac = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlivaciTermin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlivaciId = c.Int(nullable: false),
                        TerminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plivaci", t => t.PlivaciId, cascadeDelete: false)
                .ForeignKey("dbo.Termini", t => t.TerminId, cascadeDelete: false)
                .Index(t => t.PlivaciId)
                .Index(t => t.TerminId);
            
            CreateTable(
                "dbo.Uplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(),
                        Iznos = c.Int(),
                        TipUplateId = c.Int(nullable: false),
                        RekreativacId = c.Int(),
                        PlivacId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plivaci", t => t.PlivacId)
                .ForeignKey("dbo.Rekreativci", t => t.RekreativacId)
                .ForeignKey("dbo.TipUplate", t => t.TipUplateId, cascadeDelete: false)
                .Index(t => t.TipUplateId)
                .Index(t => t.RekreativacId)
                .Index(t => t.PlivacId);
            
            CreateTable(
                "dbo.Rekreativci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Spol = c.String(),
                        Kontakt = c.String(),
                        GradId = c.Int(nullable: false),
                        NalogId = c.Int(nullable: false),
                        Gradovi_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradovi", t => t.Gradovi_Id)
                .ForeignKey("dbo.Nalozi", t => t.NalogId, cascadeDelete: false)
                .Index(t => t.NalogId)
                .Index(t => t.Gradovi_Id);
            
            CreateTable(
                "dbo.RekreativciTermin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RekreativacId = c.Int(nullable: false),
                        TerminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rekreativci", t => t.RekreativacId, cascadeDelete: false)
                .ForeignKey("dbo.Termini", t => t.TerminId, cascadeDelete: false)
                .Index(t => t.RekreativacId)
                .Index(t => t.TerminId);
            
            CreateTable(
                "dbo.TipUplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UtrkePlivaci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UtrkaId = c.Int(nullable: false),
                        PlivacId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plivaci", t => t.PlivacId, cascadeDelete: false)
                .ForeignKey("dbo.Utrke", t => t.UtrkaId, cascadeDelete: false)
                .Index(t => t.UtrkaId)
                .Index(t => t.PlivacId);
            
            CreateTable(
                "dbo.Utrke",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StilUtrke = c.String(),
                        TakmicenjeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Takmicenja", t => t.TakmicenjeId, cascadeDelete: false)
                .Index(t => t.TakmicenjeId);
            
            CreateTable(
                "dbo.Takmicenja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Datum = c.DateTime(),
                        OsvojenaMjesta = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradovi", t => t.GradId, cascadeDelete: false)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Treneri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(),
                        Spol = c.String(),
                        Kontakt = c.String(),
                        Email = c.String(),
                        Zvanje = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradovi", t => t.GradId, cascadeDelete: false)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Drzave",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Izvjestaji",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Datum = c.DateTime(),
                        Opis = c.String(),
                        AdministratorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administratori", t => t.AdministratorId, cascadeDelete: false)
                .Index(t => t.AdministratorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Izvjestaji", "AdministratorId", "dbo.Administratori");
            DropForeignKey("dbo.Administratori", "NalogId", "dbo.Nalozi");
            DropForeignKey("dbo.Gradovi", "DrzavaId", "dbo.Drzave");
            DropForeignKey("dbo.Termini", "TrenerId", "dbo.Treneri");
            DropForeignKey("dbo.Treneri", "GradId", "dbo.Gradovi");
            DropForeignKey("dbo.Biljeske", "TerminId", "dbo.Termini");
            DropForeignKey("dbo.UtrkePlivaci", "UtrkaId", "dbo.Utrke");
            DropForeignKey("dbo.Utrke", "TakmicenjeId", "dbo.Takmicenja");
            DropForeignKey("dbo.Takmicenja", "GradId", "dbo.Gradovi");
            DropForeignKey("dbo.UtrkePlivaci", "PlivacId", "dbo.Plivaci");
            DropForeignKey("dbo.Uplate", "TipUplateId", "dbo.TipUplate");
            DropForeignKey("dbo.Uplate", "RekreativacId", "dbo.Rekreativci");
            DropForeignKey("dbo.RekreativciTermin", "TerminId", "dbo.Termini");
            DropForeignKey("dbo.RekreativciTermin", "RekreativacId", "dbo.Rekreativci");
            DropForeignKey("dbo.Rekreativci", "NalogId", "dbo.Nalozi");
            DropForeignKey("dbo.Rekreativci", "Gradovi_Id", "dbo.Gradovi");
            DropForeignKey("dbo.Uplate", "PlivacId", "dbo.Plivaci");
            DropForeignKey("dbo.PlivaciTermin", "TerminId", "dbo.Termini");
            DropForeignKey("dbo.PlivaciTermin", "PlivaciId", "dbo.Plivaci");
            DropForeignKey("dbo.Plivaci", "NalogId", "dbo.Nalozi");
            DropForeignKey("dbo.Termini", "GrupaId", "dbo.Grupe");
            DropForeignKey("dbo.Plivaci", "GrupaId", "dbo.Grupe");
            DropForeignKey("dbo.Plivaci", "GradId", "dbo.Gradovi");
            DropForeignKey("dbo.Biljeske", "PlivacId", "dbo.Plivaci");
            DropForeignKey("dbo.Termini", "BazenId", "dbo.Bazeni");
            DropForeignKey("dbo.Bazeni", "GradId", "dbo.Gradovi");
            DropForeignKey("dbo.Administratori", "GradId", "dbo.Gradovi");
            DropIndex("dbo.Izvjestaji", new[] { "AdministratorId" });
            DropIndex("dbo.Treneri", new[] { "GradId" });
            DropIndex("dbo.Takmicenja", new[] { "GradId" });
            DropIndex("dbo.Utrke", new[] { "TakmicenjeId" });
            DropIndex("dbo.UtrkePlivaci", new[] { "PlivacId" });
            DropIndex("dbo.UtrkePlivaci", new[] { "UtrkaId" });
            DropIndex("dbo.RekreativciTermin", new[] { "TerminId" });
            DropIndex("dbo.RekreativciTermin", new[] { "RekreativacId" });
            DropIndex("dbo.Rekreativci", new[] { "Gradovi_Id" });
            DropIndex("dbo.Rekreativci", new[] { "NalogId" });
            DropIndex("dbo.Uplate", new[] { "PlivacId" });
            DropIndex("dbo.Uplate", new[] { "RekreativacId" });
            DropIndex("dbo.Uplate", new[] { "TipUplateId" });
            DropIndex("dbo.PlivaciTermin", new[] { "TerminId" });
            DropIndex("dbo.PlivaciTermin", new[] { "PlivaciId" });
            DropIndex("dbo.Plivaci", new[] { "NalogId" });
            DropIndex("dbo.Plivaci", new[] { "GrupaId" });
            DropIndex("dbo.Plivaci", new[] { "GradId" });
            DropIndex("dbo.Biljeske", new[] { "PlivacId" });
            DropIndex("dbo.Biljeske", new[] { "TerminId" });
            DropIndex("dbo.Termini", new[] { "GrupaId" });
            DropIndex("dbo.Termini", new[] { "TrenerId" });
            DropIndex("dbo.Termini", new[] { "BazenId" });
            DropIndex("dbo.Bazeni", new[] { "GradId" });
            DropIndex("dbo.Gradovi", new[] { "DrzavaId" });
            DropIndex("dbo.Administratori", new[] { "NalogId" });
            DropIndex("dbo.Administratori", new[] { "GradId" });
            DropTable("dbo.Izvjestaji");
            DropTable("dbo.Drzave");
            DropTable("dbo.Treneri");
            DropTable("dbo.Takmicenja");
            DropTable("dbo.Utrke");
            DropTable("dbo.UtrkePlivaci");
            DropTable("dbo.TipUplate");
            DropTable("dbo.RekreativciTermin");
            DropTable("dbo.Rekreativci");
            DropTable("dbo.Uplate");
            DropTable("dbo.PlivaciTermin");
            DropTable("dbo.Nalozi");
            DropTable("dbo.Grupe");
            DropTable("dbo.Plivaci");
            DropTable("dbo.Biljeske");
            DropTable("dbo.Termini");
            DropTable("dbo.Bazeni");
            DropTable("dbo.Gradovi");
            DropTable("dbo.Administratori");
        }
    }
}
