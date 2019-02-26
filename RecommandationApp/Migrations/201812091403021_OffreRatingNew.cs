namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OffreRatingNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        value = c.Double(nullable: false),
                        Offre = c.Int(nullable: false),
                        Offre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offres", t => t.Offre_Id)
                .Index(t => t.Offre_Id);
            
            DropColumn("dbo.Offres", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offres", "Rating", c => c.Double(nullable: false));
            DropForeignKey("dbo.Ratings", "Offre_Id", "dbo.Offres");
            DropIndex("dbo.Ratings", new[] { "Offre_Id" });
            DropTable("dbo.Ratings");
        }
    }
}
