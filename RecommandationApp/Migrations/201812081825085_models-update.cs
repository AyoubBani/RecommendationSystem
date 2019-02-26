namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Offre_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Offre_Id");
            AddForeignKey("dbo.Comments", "Offre_Id", "dbo.Offres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Offre_Id", "dbo.Offres");
            DropIndex("dbo.Comments", new[] { "Offre_Id" });
            DropColumn("dbo.Comments", "Offre_Id");
        }
    }
}
