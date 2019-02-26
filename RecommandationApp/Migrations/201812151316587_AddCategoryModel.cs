namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "IdCategory", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "IdCategory");
        }
    }
}
