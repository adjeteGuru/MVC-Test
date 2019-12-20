﻿namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        DateCreated = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        TXDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        ClientId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                        SchType = c.Int(nullable: false),
                        JobId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Has_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Schedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Schedule", t => t.Schedule_Id)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId)
                .Index(t => t.Schedule_Id);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        Has_RoleId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TotalHours = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Has_Role", t => t.Has_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.ScheduleId)
                .Index(t => t.Has_RoleId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        CountyId = c.Int(nullable: false),
                        bared = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "JobId", "dbo.Job");
            DropForeignKey("dbo.Has_Role", "Schedule_Id", "dbo.Schedule");
            DropForeignKey("dbo.Has_Role", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Has_Role", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Crew", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Employee", "CountyId", "dbo.County");
            DropForeignKey("dbo.Crew", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.Crew", "Has_RoleId", "dbo.Has_Role");
            DropForeignKey("dbo.Job", "ClientId", "dbo.Client");
            DropIndex("dbo.Employee", new[] { "CountyId" });
            DropIndex("dbo.Crew", new[] { "Employee_Id" });
            DropIndex("dbo.Crew", new[] { "Has_RoleId" });
            DropIndex("dbo.Crew", new[] { "ScheduleId" });
            DropIndex("dbo.Has_Role", new[] { "Schedule_Id" });
            DropIndex("dbo.Has_Role", new[] { "RoleId" });
            DropIndex("dbo.Has_Role", new[] { "EmployeeId" });
            DropIndex("dbo.Schedule", new[] { "JobId" });
            DropIndex("dbo.Job", new[] { "ClientId" });
            DropTable("dbo.Role");
            DropTable("dbo.County");
            DropTable("dbo.Employee");
            DropTable("dbo.Crew");
            DropTable("dbo.Has_Role");
            DropTable("dbo.Schedule");
            DropTable("dbo.Job");
            DropTable("dbo.Client");
        }
    }
}
