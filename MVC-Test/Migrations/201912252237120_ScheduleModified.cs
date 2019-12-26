namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Has_Role", "Schedule_Id", "dbo.Schedule");
            DropIndex("dbo.Has_Role", new[] { "Schedule_Id" });
            DropColumn("dbo.Has_Role", "Schedule_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Has_Role", "Schedule_Id", c => c.Int());
            CreateIndex("dbo.Has_Role", "Schedule_Id");
            AddForeignKey("dbo.Has_Role", "Schedule_Id", "dbo.Schedule", "Id");
        }
    }
}
