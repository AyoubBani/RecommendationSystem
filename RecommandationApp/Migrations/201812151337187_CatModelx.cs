namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatModelx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Offres", "IdCategory", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "IdCategory");
            DropTable("dbo.CategoryMs");
        }
    }
}
