namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableToDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Job", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Job", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Job", "TXDate", c => c.DateTime());
            AlterColumn("dbo.Job", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Schedule", "start_date", c => c.DateTime());
            AlterColumn("dbo.Schedule", "end_date", c => c.DateTime());
            AlterColumn("dbo.Has_Role", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Has_Role", "EndTime", c => c.DateTime());
            AlterColumn("dbo.Crew", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Crew", "EndTime", c => c.DateTime());
            AlterColumn("dbo.Employee", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Crew", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Crew", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Has_Role", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Has_Role", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedule", "end_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedule", "start_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Job", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Job", "TXDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Job", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Job", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
