namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Clients");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropTable("dbo.Comments");
        }
    }
}
