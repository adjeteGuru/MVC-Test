namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Tel = c.Int(nullable: false),
                        Email = c.String(),
                        ToContact = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        StartDate = c.DateTime(),
                        TXDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        ClientId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(maxLength: 128),
                        Has_RoleId = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        TotalDays = c.Double(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Has_Role", t => t.Has_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.Job", t => t.JobId)
                .Index(t => t.JobId)
                .Index(t => t.Has_RoleId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Has_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Category = c.Int(nullable: false),
                        CountyId = c.Int(nullable: false),
                        bared = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        StartDate = c.DateTime(),
                        Photo = c.String(),
                        NextOfKin = c.String(),
                        Alergy = c.String(),
                        Note = c.String(),
                        PostNominals = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.County", t => t.CountyId, cascadeDelete: true)
                .Index(t => t.CountyId);
            
            CreateTable(
                "dbo.County",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                        SchType = c.Int(nullable: false),
                        JobId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.JobDisplayViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        StartDate = c.DateTime(),
                        TXDate = c.DateTime(),
                        EndDate = c.DateTime(),
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
                        Name = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        StartDate = c.DateTime(),
                        TXDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        SelectedClientId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobSchedulesListViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        StartDate = c.DateTime(),
                        TXDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        ClientName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobSchedulesListViewModel", t => t.JobSchedulesListViewModel_Id)
                .Index(t => t.JobSchedulesListViewModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleDisplayViewModel", "JobSchedulesListViewModel_Id", "dbo.JobSchedulesListViewModel");
            DropForeignKey("dbo.Schedule", "JobId", "dbo.Job");
            DropForeignKey("dbo.Crew", "JobId", "dbo.Job");
            DropForeignKey("dbo.Has_Role", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Has_Role", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Crew", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Employee", "CountyId", "dbo.County");
            DropForeignKey("dbo.Crew", "Has_RoleId", "dbo.Has_Role");
            DropForeignKey("dbo.Job", "ClientId", "dbo.Client");
            DropIndex("dbo.ScheduleDisplayViewModel", new[] { "JobSchedulesListViewModel_Id" });
            DropIndex("dbo.Schedule", new[] { "JobId" });
            DropIndex("dbo.Employee", new[] { "CountyId" });
            DropIndex("dbo.Has_Role", new[] { "RoleId" });
            DropIndex("dbo.Has_Role", new[] { "EmployeeId" });
            DropIndex("dbo.Crew", new[] { "Employee_Id" });
            DropIndex("dbo.Crew", new[] { "Has_RoleId" });
            DropIndex("dbo.Crew", new[] { "JobId" });
            DropIndex("dbo.Job", new[] { "ClientId" });
            DropTable("dbo.ScheduleDisplayViewModel");
            DropTable("dbo.JobSchedulesListViewModel");
            DropTable("dbo.JobEditViewModel");
            DropTable("dbo.JobDisplayViewModel");
            DropTable("dbo.Schedule");
            DropTable("dbo.Role");
            DropTable("dbo.County");
            DropTable("dbo.Employee");
            DropTable("dbo.Has_Role");
            DropTable("dbo.Crew");
            DropTable("dbo.Job");
            DropTable("dbo.Client");
        }
    }
}
