namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Client_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ratings", "Client_Id");
            AddForeignKey("dbo.Ratings", "Client_Id", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Ratings", new[] { "Client_Id" });
            DropColumn("dbo.Ratings", "Client_Id");
        }
    }
}
