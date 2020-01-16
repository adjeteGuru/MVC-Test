namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate_Newd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobEditViewModel", "text", c => c.String());
            AddColumn("dbo.JobEditViewModel", "start_date", c => c.DateTime());
            AddColumn("dbo.JobEditViewModel", "end_date", c => c.DateTime());
            DropColumn("dbo.JobEditViewModel", "Name");
            DropColumn("dbo.JobEditViewModel", "StartDate");
            DropColumn("dbo.JobEditViewModel", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobEditViewModel", "EndDate", c => c.DateTime());
            AddColumn("dbo.JobEditViewModel", "StartDate", c => c.DateTime());
            AddColumn("dbo.JobEditViewModel", "Name", c => c.String());
            DropColumn("dbo.JobEditViewModel", "end_date");
            DropColumn("dbo.JobEditViewModel", "start_date");
            DropColumn("dbo.JobEditViewModel", "text");
        }
    }
}
