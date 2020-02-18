namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingType",
                c => new
                    {
                        BookingTypeID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.BookingTypeID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        tel = c.Int(nullable: false),
                        email = c.String(),
                        toContact = c.String(),
                        address = c.String(),
                        Clients_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Clients_Id)
                .Index(t => t.Clients_Id);
            
            CreateTable(
                "dbo.County",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        crewId = c.Int(nullable: false, identity: true),
                        JobId = c.Guid(nullable: false),
                        has_RoleId = c.Int(nullable: false),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                        totalDays = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.crewId)
                .ForeignKey("dbo.Has_Role", t => t.has_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.has_RoleId);
            
            CreateTable(
                "dbo.Has_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        employeeId = c.Int(nullable: false),
                        roleId = c.Int(nullable: false),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                        rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.employeeId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.roleId, cascadeDelete: true)
                .Index(t => t.employeeId)
                .Index(t => t.roleId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        mobile = c.String(),
                        email = c.String(),
                        Category = c.Int(nullable: false),
                        countyId = c.Int(nullable: false),
                        bared = c.String(),
                        isAvailable = c.Boolean(nullable: false),
                        start_date = c.DateTime(),
                        photo = c.String(),
                        nextOfKin = c.String(),
                        alergy = c.String(),
                        note = c.String(),
                        postNominals = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.County", t => t.countyId, cascadeDelete: true)
                .Index(t => t.countyId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        JobRef = c.String(),
                        text = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        DateCreated = c.DateTime(),
                        start_date = c.DateTime(),
                        TXDate = c.DateTime(),
                        end_date = c.DateTime(),
                        Coordinator = c.String(),
                        CommercialLead = c.String(),
                        ClientId = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ScheduleEdit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.String(),
                        text = c.String(),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                        SchType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Guid(nullable: false),
                        text = c.String(),
                        start_date = c.DateTime(),
                        end_date = c.DateTime(),
                        SchType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Crew", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role");
            DropForeignKey("dbo.Has_Role", "roleId", "dbo.Role");
            DropForeignKey("dbo.Has_Role", "employeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "countyId", "dbo.County");
            DropForeignKey("dbo.Client", "Clients_Id", "dbo.Client");
            DropIndex("dbo.Schedule", new[] { "JobId" });
            DropIndex("dbo.Jobs", new[] { "ClientId" });
            DropIndex("dbo.Employee", new[] { "countyId" });
            DropIndex("dbo.Has_Role", new[] { "roleId" });
            DropIndex("dbo.Has_Role", new[] { "employeeId" });
            DropIndex("dbo.Crew", new[] { "has_RoleId" });
            DropIndex("dbo.Crew", new[] { "JobId" });
            DropIndex("dbo.Client", new[] { "Clients_Id" });
            DropTable("dbo.Schedule");
            DropTable("dbo.ScheduleEdit");
            DropTable("dbo.Jobs");
            DropTable("dbo.Role");
            DropTable("dbo.Employee");
            DropTable("dbo.Has_Role");
            DropTable("dbo.Crew");
            DropTable("dbo.County");
            DropTable("dbo.Client");
            DropTable("dbo.BookingType");
        }
    }
}
