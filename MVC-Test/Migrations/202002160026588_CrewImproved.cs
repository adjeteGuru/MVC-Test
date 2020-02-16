namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrewImproved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Crew", "Has_Role_Id", "dbo.Has_Role");
            DropForeignKey("dbo.Crew", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Schedule", "JobId", "dbo.Jobs");
            DropIndex("dbo.Crew", new[] { "Has_Role_Id" });
            DropColumn("dbo.Crew", "has_RoleId");
            RenameColumn(table: "dbo.Crew", name: "Has_Role_Id", newName: "has_RoleId");
            DropPrimaryKey("dbo.Crew");
            DropPrimaryKey("dbo.Jobs");
            AddColumn("dbo.Crew", "crewId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Crew", "quatity", c => c.Int(nullable: false));
            AlterColumn("dbo.Crew", "has_RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Crew", "has_RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "JobId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Crew", "crewId");
            AddPrimaryKey("dbo.Jobs", "JobId");
            CreateIndex("dbo.Crew", "has_RoleId");
            AddForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Crew", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.Schedule", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            DropColumn("dbo.Crew", "rate");
            DropColumn("dbo.Has_Role", "start_date");
            DropColumn("dbo.Has_Role", "end_date");
            DropColumn("dbo.Has_Role", "totalDays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Has_Role", "totalDays", c => c.Double(nullable: false));
            AddColumn("dbo.Has_Role", "end_date", c => c.DateTime());
            AddColumn("dbo.Has_Role", "start_date", c => c.DateTime());
            AddColumn("dbo.Crew", "rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Schedule", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Crew", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role");
            DropIndex("dbo.Crew", new[] { "has_RoleId" });
            DropPrimaryKey("dbo.Jobs");
            DropPrimaryKey("dbo.Crew");
            AlterColumn("dbo.Jobs", "JobId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Crew", "has_RoleId", c => c.Int());
            AlterColumn("dbo.Crew", "has_RoleId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Crew", "quatity");
            DropColumn("dbo.Crew", "crewId");
            AddPrimaryKey("dbo.Jobs", "JobId");
            AddPrimaryKey("dbo.Crew", "has_RoleId");
            RenameColumn(table: "dbo.Crew", name: "has_RoleId", newName: "Has_Role_Id");
            AddColumn("dbo.Crew", "has_RoleId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Crew", "Has_Role_Id");
            AddForeignKey("dbo.Schedule", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.Crew", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.Crew", "Has_Role_Id", "dbo.Has_Role", "Id");
        }
    }
}
