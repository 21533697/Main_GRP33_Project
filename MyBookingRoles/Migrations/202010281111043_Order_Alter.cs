namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order_Alter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Orders", "PostalCode", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Experation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CreditCard", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "CreditCardNumber", c => c.String());
            AddColumn("dbo.Orders", "CcType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CcType");
            DropColumn("dbo.Orders", "CreditCardNumber");
            DropColumn("dbo.Orders", "CreditCard");
            DropColumn("dbo.Orders", "Experation");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "LastName");
        }
    }
}
