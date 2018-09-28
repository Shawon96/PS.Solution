namespace PS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bla_Bla_Changed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "BookTime");
            DropTable("dbo.Bills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PlaceName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Bookings", "BookTime", c => c.DateTime(nullable: false));
        }
    }
}
