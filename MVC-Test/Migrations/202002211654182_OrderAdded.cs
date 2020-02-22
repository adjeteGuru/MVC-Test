namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        ServiceName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        JobId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "JobId", "dbo.Jobs");
            DropIndex("dbo.Order", new[] { "JobId" });
            DropTable("dbo.Order");
        }
    }
}
