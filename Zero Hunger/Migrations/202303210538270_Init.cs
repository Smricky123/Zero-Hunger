namespace Zero_Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectReqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        CollectionDate = c.DateTime(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectReqs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.CollectReqs", new[] { "EmployeeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.CollectReqs");
        }
    }
}
