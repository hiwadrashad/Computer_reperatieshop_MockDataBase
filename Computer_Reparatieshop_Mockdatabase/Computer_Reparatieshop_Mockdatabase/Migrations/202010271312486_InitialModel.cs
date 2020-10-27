namespace Computer_Reparatieshop_Mockdatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        LoginErrorMessage = c.String(),
                        Naam = c.String(),
                        Straatnaam = c.String(),
                        AdressNummer = c.Int(nullable: false),
                        PostCode = c.String(),
                        Plaats = c.String(),
                        telefoonnummer = c.String(),
                        rol = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GebruikersNaam = c.String(),
                        LoginErrorMessage = c.String(),
                        Wachtwoord = c.String(),
                        Naam = c.String(),
                        Straatnaam = c.String(),
                        AdressNummer = c.Int(nullable: false),
                        PostCode = c.String(),
                        Plaats = c.String(),
                        telefoonnummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelBestellings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        omschrijving = c.String(),
                        Datum = c.DateTime(),
                        ophalen = c.Int(nullable: false),
                        extrainformatie = c.String(),
                        ClientLogin_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientModels", t => t.ClientLogin_Id)
                .Index(t => t.ClientLogin_Id);
            
            CreateTable(
                "dbo.ModelReparaties",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StartDatum = c.DateTime(),
                        EindDatum = c.DateTime(),
                        status = c.String(),
                        Omschrijving = c.String(),
                        PrijsProducten = c.Double(nullable: false),
                        PrijsArbeid = c.Double(nullable: false),
                        Totaal = c.Double(nullable: false),
                        Klant_Id = c.String(maxLength: 128),
                        onderdelen_id = c.String(maxLength: 128),
                        Reparateur_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientModels", t => t.Klant_Id)
                .ForeignKey("dbo.PartModels", t => t.onderdelen_id)
                .ForeignKey("dbo.ParentModels", t => t.Reparateur_Id)
                .Index(t => t.Klant_Id)
                .Index(t => t.onderdelen_id)
                .Index(t => t.Reparateur_Id);
            
            CreateTable(
                "dbo.PartModels",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        numberofpartsavailable = c.Int(nullable: false),
                        qualityofpart = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ModelStatus",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        aantalinafwachting = c.Int(nullable: false),
                        aantalinbehandeling = c.Int(nullable: false),
                        aantalwachtoponderdelen = c.Int(nullable: false),
                        aantaalklaar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelReparaties", "Reparateur_Id", "dbo.ParentModels");
            DropForeignKey("dbo.ModelReparaties", "onderdelen_id", "dbo.PartModels");
            DropForeignKey("dbo.ModelReparaties", "Klant_Id", "dbo.ClientModels");
            DropForeignKey("dbo.ModelBestellings", "ClientLogin_Id", "dbo.ClientModels");
            DropIndex("dbo.ModelReparaties", new[] { "Reparateur_Id" });
            DropIndex("dbo.ModelReparaties", new[] { "onderdelen_id" });
            DropIndex("dbo.ModelReparaties", new[] { "Klant_Id" });
            DropIndex("dbo.ModelBestellings", new[] { "ClientLogin_Id" });
            DropTable("dbo.ModelStatus");
            DropTable("dbo.PartModels");
            DropTable("dbo.ModelReparaties");
            DropTable("dbo.ModelBestellings");
            DropTable("dbo.ClientModels");
            DropTable("dbo.ParentModels");
        }
    }
}
