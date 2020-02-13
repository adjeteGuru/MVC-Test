namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202002131046574_202002122042582_InitialCreate_New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobRef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobRef");
        }
    }
}
