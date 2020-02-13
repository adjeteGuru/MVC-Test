namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202002122042582_InitialCreate_New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Clients_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Client", "Clients_Id");
            AddForeignKey("dbo.Client", "Clients_Id", "dbo.Client", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "Clients_Id", "dbo.Client");
            DropIndex("dbo.Client", new[] { "Clients_Id" });
            DropColumn("dbo.Client", "Clients_Id");
        }
    }
}
