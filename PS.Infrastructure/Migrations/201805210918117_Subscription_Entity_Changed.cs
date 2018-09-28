namespace PS.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscription_Entity_Changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Subscriptions", "IsPending", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "IsPending");
            DropColumn("dbo.Subscriptions", "Date");
        }
    }
}
