namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bookings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        ArtistID = c.String(),
                        LocationId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        BookingFee = c.Double(nullable: false),
                        ArtistRateFee = c.Double(nullable: false),
                        LocationVenueFee = c.Double(nullable: false),
                        PackageCost = c.Double(nullable: false),
                        EventFee = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        TotalDue = c.Double(nullable: false),
                        Status = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.PackageId)
                .Index(t => t.ServiceId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationType = c.String(),
                        LocationPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        PackageType = c.String(),
                        PackagePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PackageId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceType = c.String(),
                        ServicePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Bookings", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Bookings", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Bookings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Bookings", new[] { "ServiceId" });
            DropIndex("dbo.Bookings", new[] { "PackageId" });
            DropIndex("dbo.Bookings", new[] { "LocationId" });
            DropTable("dbo.Services");
            DropTable("dbo.Packages");
            DropTable("dbo.Locations");
            DropTable("dbo.Bookings");
        }
    }
}
