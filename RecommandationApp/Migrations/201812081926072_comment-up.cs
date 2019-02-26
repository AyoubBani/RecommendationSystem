namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Offre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Offre");
        }
    }
}
