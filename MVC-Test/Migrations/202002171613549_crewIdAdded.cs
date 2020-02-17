namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crewIdAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Crew");
            AddColumn("dbo.Crew", "crewId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Has_Role", "start_date", c => c.DateTime());
            AddColumn("dbo.Has_Role", "end_date", c => c.DateTime());
            AddPrimaryKey("dbo.Crew", "crewId");
            DropColumn("dbo.Crew", "quatity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "quatity", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Crew");
            DropColumn("dbo.Has_Role", "end_date");
            DropColumn("dbo.Has_Role", "start_date");
            DropColumn("dbo.Crew", "crewId");
            AddPrimaryKey("dbo.Crew", new[] { "JobId", "has_RoleId" });
        }
    }
}
