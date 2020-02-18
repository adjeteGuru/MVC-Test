namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202002180957085_InitialCreate_IdChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role");
            DropPrimaryKey("dbo.Has_Role");
            AddColumn("dbo.Has_Role", "has_RoleId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Has_Role", "has_RoleId");
            AddForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role", "has_RoleId", cascadeDelete: true);
            DropColumn("dbo.Has_Role", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Has_Role", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role");
            DropPrimaryKey("dbo.Has_Role");
            DropColumn("dbo.Has_Role", "has_RoleId");
            AddPrimaryKey("dbo.Has_Role", "Id");
            AddForeignKey("dbo.Crew", "has_RoleId", "dbo.Has_Role", "Id", cascadeDelete: true);
        }
    }
}
