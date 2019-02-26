namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "image");
        }
    }
}
