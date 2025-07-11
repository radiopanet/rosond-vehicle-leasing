namespace RosondVehicleLeasing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        Manager = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        ProcumentDate = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.ClientId)
                .Index(t => t.DriverId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        LicenseNumber = c.String(),
                        LicenseExpiry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Vehicles", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Vehicles", "BranchId", "dbo.Branches");
            DropIndex("dbo.Vehicles", new[] { "SupplierId" });
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropIndex("dbo.Vehicles", new[] { "ClientId" });
            DropIndex("dbo.Vehicles", new[] { "BranchId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Clients");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Branches");
        }
    }
}
