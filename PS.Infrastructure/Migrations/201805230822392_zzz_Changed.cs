namespace PS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zzz_Changed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        CarUserId = c.Int(nullable: false),
                        ToPlaceId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlaceReviews");
        }
    }
}
