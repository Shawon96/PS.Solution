namespace PS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking_Entity_Changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "PromoCode", c => c.String());
            DropColumn("dbo.Bookings", "Start");
            DropColumn("dbo.Bookings", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "End", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bookings", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bookings", "PromoCode");
        }
    }
}
