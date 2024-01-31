namespace TcpOdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignPriceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaigns", "Price");
        }
    }
}
