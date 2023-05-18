namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvendorname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplyPermissions", "VendorName", c => c.String(maxLength: 128));
            AddColumn("dbo.SupplyPermissions", "VendorPhone", c => c.String(maxLength: 128));
            CreateIndex("dbo.SupplyPermissions", new[] { "VendorName", "VendorPhone" });
            AddForeignKey("dbo.SupplyPermissions", new[] { "VendorName", "VendorPhone" }, "dbo.Vendors", new[] { "Name", "Phone" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplyPermissions", new[] { "VendorName", "VendorPhone" }, "dbo.Vendors");
            DropIndex("dbo.SupplyPermissions", new[] { "VendorName", "VendorPhone" });
            DropColumn("dbo.SupplyPermissions", "VendorPhone");
            DropColumn("dbo.SupplyPermissions", "VendorName");
        }
    }
}
