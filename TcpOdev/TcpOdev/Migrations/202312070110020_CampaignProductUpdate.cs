namespace TcpOdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignProductUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CampaignId", "dbo.Campaigns");
            DropIndex("dbo.Products", new[] { "CampaignId" });
            DropColumn("dbo.Products", "CampaignId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CampaignId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CampaignId");
            AddForeignKey("dbo.Products", "CampaignId", "dbo.Campaigns", "Id", cascadeDelete: true);
        }
    }
}
