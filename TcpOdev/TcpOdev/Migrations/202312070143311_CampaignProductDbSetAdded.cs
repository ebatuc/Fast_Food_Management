namespace TcpOdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignProductDbSetAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampaignProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CampaignId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampaignProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CampaignProducts", "CampaignId", "dbo.Campaigns");
            DropIndex("dbo.CampaignProducts", new[] { "CampaignId" });
            DropIndex("dbo.CampaignProducts", new[] { "ProductId" });
            DropTable("dbo.CampaignProducts");
        }
    }
}
