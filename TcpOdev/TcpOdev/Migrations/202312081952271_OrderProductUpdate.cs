namespace TcpOdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderProductUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderProducts", "Name");
            DropColumn("dbo.OrderProducts", "IsStatus");
            DropColumn("dbo.OrderProducts", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProducts", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderProducts", "IsStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderProducts", "Name", c => c.String());
        }
    }
}
