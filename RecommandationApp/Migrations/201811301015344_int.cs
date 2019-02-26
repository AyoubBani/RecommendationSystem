namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Offres", "Image1");
            DropColumn("dbo.Offres", "Image2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offres", "Image2", c => c.Binary());
            AddColumn("dbo.Offres", "Image1", c => c.Binary());
        }
    }
}
