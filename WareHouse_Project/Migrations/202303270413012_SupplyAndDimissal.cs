namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplyAndDimissal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DismissalNotices",
                c => new
                    {
                        CustomerName = c.String(maxLength: 128),
                        CustomerPhone = c.String(maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CategoryCode = c.Int(nullable: false),
                        WareHousesName = c.String(maxLength: 200),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryCode, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => new { t.CustomerName, t.CustomerPhone })
                .ForeignKey("dbo.WareHouses", t => t.WareHousesName)
                .Index(t => new { t.CustomerName, t.CustomerPhone })
                .Index(t => t.CategoryCode)
                .Index(t => t.WareHousesName);
            
            AddColumn("dbo.SupplyPermissions", "ProductionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SupplyPermissions", "ExpiratoinDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DismissalNotices", "WareHousesName", "dbo.WareHouses");
            DropForeignKey("dbo.DismissalNotices", new[] { "CustomerName", "CustomerPhone" }, "dbo.Customers");
            DropForeignKey("dbo.DismissalNotices", "CategoryCode", "dbo.Categories");
            DropIndex("dbo.DismissalNotices", new[] { "WareHousesName" });
            DropIndex("dbo.DismissalNotices", new[] { "CategoryCode" });
            DropIndex("dbo.DismissalNotices", new[] { "CustomerName", "CustomerPhone" });
            DropColumn("dbo.SupplyPermissions", "ExpiratoinDate");
            DropColumn("dbo.SupplyPermissions", "ProductionDate");
            DropTable("dbo.DismissalNotices");
        }
    }
}
