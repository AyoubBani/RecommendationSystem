namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tpo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "Image1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "Image1");
        }
    }
}
