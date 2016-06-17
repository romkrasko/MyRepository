namespace WebParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkingDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Mark = c.String(),
                        Model = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                        Post = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpirtionDate = c.DateTime(nullable: false),
                        Cost = c.Int(nullable: false),
                        PlaceNumber = c.Int(nullable: false),
                        ParkingId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Parkings", t => t.ParkingId, cascadeDelete: true)
                .Index(t => t.ParkingId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        PlaceCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "ParkingId", "dbo.Parkings");
            DropForeignKey("dbo.Subscriptions", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Subscriptions", new[] { "CarId" });
            DropIndex("dbo.Subscriptions", new[] { "ParkingId" });
            DropIndex("dbo.Cars", new[] { "EmployeeId" });
            DropTable("dbo.Parkings");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Employees");
            DropTable("dbo.Cars");
        }
    }
}
