namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nom = c.String(maxLength: 25),
                        prenom = c.String(maxLength: 25),
                        sex = c.String(maxLength: 10),
                        dateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Representants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nom = c.String(maxLength: 25),
                        prenom = c.String(maxLength: 25),
                        entreprise = c.String(maxLength: 255),
                        adresse_entreprise = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "is_representant", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Representants", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Representants", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "Id" });
            DropColumn("dbo.AspNetUsers", "is_representant");
            DropTable("dbo.Representants");
            DropTable("dbo.Clients");
        }
    }
}
