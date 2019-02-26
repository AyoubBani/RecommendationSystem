namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentUserRename : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "Client_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_Client_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_Client_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Comments", name: "Client_Id", newName: "User_Id");
        }
    }
}
