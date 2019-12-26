namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Crew", "Employee_Id", "dbo.Employee");
            DropIndex("dbo.Crew", new[] { "Employee_Id" });
            DropColumn("dbo.Crew", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Crew", "Employee_Id");
            AddForeignKey("dbo.Crew", "Employee_Id", "dbo.Employee", "Id");
        }
    }
}
