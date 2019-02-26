namespace RecommandationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "profileImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "profileImage");
        }
    }
}
