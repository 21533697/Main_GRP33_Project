namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appusertt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Bookings", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bookings", "ApplicationUser_Id");
            AddForeignKey("dbo.Bookings", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
