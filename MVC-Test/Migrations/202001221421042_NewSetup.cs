namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSetup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleDisplayViewModel", "JobSchedulesListViewModel_Id", "dbo.JobSchedulesListViewModel");
            DropIndex("dbo.ScheduleDisplayViewModel", new[] { "JobSchedulesListViewModel_Id" });
            DropTable("dbo.JobDisplayViewModel");
            DropTable("dbo.JobEditViewModel");
            DropTable("dbo.JobSchedulesListViewModel");
            DropTable("dbo.ScheduleDisplayViewModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ScheduleDisplayViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        SchType = c.Int(nullable: false),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                        JobId = c.String(),
                        JobSchedulesListViewModel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobSchedulesListViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        text = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        start_date = c.DateTime(),
                        TXDate = c.DateTime(),
                        end_date = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        ClientName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobEditViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        text = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        start_date = c.DateTime(),
                        TXDate = c.DateTime(),
                        end_date = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        SelectedClientId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobDisplayViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        text = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        start_date = c.DateTime(),
                        TXDate = c.DateTime(),
                        end_date = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        ClientName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ScheduleDisplayViewModel", "JobSchedulesListViewModel_Id");
            AddForeignKey("dbo.ScheduleDisplayViewModel", "JobSchedulesListViewModel_Id", "dbo.JobSchedulesListViewModel", "Id");
        }
    }
}
