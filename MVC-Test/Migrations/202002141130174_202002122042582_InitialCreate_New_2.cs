namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202002122042582_InitialCreate_New_2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScheduleEdit");
        }
    }
}
