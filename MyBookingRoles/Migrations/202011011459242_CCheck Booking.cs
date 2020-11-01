namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CCheckBooking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "ArtistID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "ArtistID", c => c.String());
        }
    }
}
