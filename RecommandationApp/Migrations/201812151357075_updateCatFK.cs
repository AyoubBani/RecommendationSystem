namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCatFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Offres", "IdCategoryM");
            AddForeignKey("dbo.Offres", "IdCategoryM", "dbo.CategoryMs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offres", "IdCategoryM", "dbo.CategoryMs");
            DropIndex("dbo.Offres", new[] { "IdCategoryM" });
        }
    }
}
