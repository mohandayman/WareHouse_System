namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configureDismassil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DismissalNotices", new[] { "CustomerName", "CustomerPhone" }, "dbo.Customers");
            DropIndex("dbo.DismissalNotices", new[] { "CustomerName", "CustomerPhone" });
            AddColumn("dbo.DismissalNotices", "VendorName", c => c.String(maxLength: 128));
            AddColumn("dbo.DismissalNotices", "VendorPhone", c => c.String(maxLength: 128));
            CreateIndex("dbo.DismissalNotices", new[] { "VendorName", "VendorPhone" });
            AddForeignKey("dbo.DismissalNotices", new[] { "VendorName", "VendorPhone" }, "dbo.Vendors", new[] { "Name", "Phone" });
            DropColumn("dbo.DismissalNotices", "CustomerName");
            DropColumn("dbo.DismissalNotices", "CustomerPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DismissalNotices", "CustomerPhone", c => c.String(maxLength: 128));
            AddColumn("dbo.DismissalNotices", "CustomerName", c => c.String(maxLength: 128));
            DropForeignKey("dbo.DismissalNotices", new[] { "VendorName", "VendorPhone" }, "dbo.Vendors");
            DropIndex("dbo.DismissalNotices", new[] { "VendorName", "VendorPhone" });
            DropColumn("dbo.DismissalNotices", "VendorPhone");
            DropColumn("dbo.DismissalNotices", "VendorName");
            CreateIndex("dbo.DismissalNotices", new[] { "CustomerName", "CustomerPhone" });
            AddForeignKey("dbo.DismissalNotices", new[] { "CustomerName", "CustomerPhone" }, "dbo.Customers", new[] { "Name", "Phone" });
        }
    }
}
