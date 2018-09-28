namespace PS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Description = c.String(),
                        Popularity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logininfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                        IsBlocked = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        ParkingRate = c.Double(nullable: false),
                        FixDiscount = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ParkingPlaces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        SpotName = c.String(),
                        SpotLocation = c.String(),
                        PricePerHour = c.Double(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lon = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Promoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        PromoCode = c.String(),
                        DiscountRate = c.Single(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        FromUserId = c.Int(nullable: false),
                        ToUserId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                        CarModel = c.String(),
                        LicensNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.Requests");
            DropTable("dbo.Promoes");
            DropTable("dbo.ParkingPlaces");
            DropTable("dbo.Owners");
            DropTable("dbo.Offers");
            DropTable("dbo.Logininfoes");
            DropTable("dbo.Facilities");
            DropTable("dbo.Bookings");
        }
    }
}
