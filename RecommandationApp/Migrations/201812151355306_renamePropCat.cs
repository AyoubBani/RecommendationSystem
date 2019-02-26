namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamePropCat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "IdCategoryM", c => c.Int(nullable: false));
            DropColumn("dbo.Offres", "IdCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offres", "IdCategory", c => c.Int());
            DropColumn("dbo.Offres", "IdCategoryM");
        }
    }
}
