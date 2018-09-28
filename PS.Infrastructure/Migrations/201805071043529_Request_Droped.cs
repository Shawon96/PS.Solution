namespace PS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Request_Droped : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Requests", newName: "Subscriptions");
            AddColumn("dbo.Bookings", "IsPending", c => c.Int(nullable: false));
            AddColumn("dbo.ParkingPlaces", "IsBlocked", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkingPlaces", "IsBlocked");
            DropColumn("dbo.Bookings", "IsPending");
            RenameTable(name: "dbo.Subscriptions", newName: "Requests");
        }
    }
}
