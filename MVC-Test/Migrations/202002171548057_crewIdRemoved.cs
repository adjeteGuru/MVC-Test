namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crewIdRemoved : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Crew");
            AddPrimaryKey("dbo.Crew", new[] { "JobId", "has_RoleId" });
            DropColumn("dbo.Crew", "crewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "crewId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Crew");
            AddPrimaryKey("dbo.Crew", "crewId");
        }
    }
}
