namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RateUnitAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Has_Role", "totalDays", c => c.Double(nullable: false));
            AddColumn("dbo.Has_Role", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Crew", "totalDays", c => c.Double(nullable: false));
            AddColumn("dbo.Crew", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Crew", "TotalHours");
            DropColumn("dbo.Crew", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Crew", "TotalHours", c => c.Int(nullable: false));
            DropColumn("dbo.Crew", "Rate");
            DropColumn("dbo.Crew", "totalDays");
            DropColumn("dbo.Has_Role", "Rate");
            DropColumn("dbo.Has_Role", "totalDays");
        }
    }
}
