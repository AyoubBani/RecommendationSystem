namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OffreRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "Rating");
        }
    }
}
