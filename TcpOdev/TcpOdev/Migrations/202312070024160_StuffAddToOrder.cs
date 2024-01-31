namespace TcpOdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StuffAddToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "StuffId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "StuffId");
            AddForeignKey("dbo.Orders", "StuffId", "dbo.Stuffs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StuffId", "dbo.Stuffs");
            DropIndex("dbo.Orders", new[] { "StuffId" });
            DropColumn("dbo.Orders", "StuffId");
        }
    }
}
