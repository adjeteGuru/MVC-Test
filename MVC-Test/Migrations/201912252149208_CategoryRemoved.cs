namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Crew", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "Category", c => c.Int(nullable: false));
        }
    }
}
