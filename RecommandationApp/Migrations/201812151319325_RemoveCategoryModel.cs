namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Offres", "IdCategory");
//            DropTable("dbo.Category");
        }
        
        public override void Down()
        {   
            AddColumn("dbo.Offres", "IdCategory", c => c.Int());
        }
    }
}
