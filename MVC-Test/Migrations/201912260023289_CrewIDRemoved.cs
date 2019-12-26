namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrewIDRemoved : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Crew");
            AddPrimaryKey("dbo.Crew", new[] { "ScheduleId", "Has_RoleId" });
            DropColumn("dbo.Crew", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Crew");
            AddPrimaryKey("dbo.Crew", "Id");
        }
    }
}
