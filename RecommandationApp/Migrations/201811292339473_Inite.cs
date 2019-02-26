namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AdresseRecomo = c.String(),
                        TelRecomo = c.String(),
                        Image1 = c.Binary(),
                        Image2 = c.Binary(),
                        IdRepresentant = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Representants", t => t.IdRepresentant)
                .Index(t => t.IdRepresentant);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offres", "IdRepresentant", "dbo.Representants");
            DropIndex("dbo.Offres", new[] { "IdRepresentant" });
            DropTable("dbo.Offres");
        }
    }
}
