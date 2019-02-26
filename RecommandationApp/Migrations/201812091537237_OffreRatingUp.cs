namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OffreRatingUp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ratings", "Offre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Offre", c => c.Int(nullable: false));
        }
    }
}
