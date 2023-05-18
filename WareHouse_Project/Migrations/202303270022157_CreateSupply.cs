namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSupply : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WareHouseCategories", "WareHouse_WareHouseName", "dbo.WareHouses");
            DropForeignKey("dbo.WareHouseCategories", "Category_Code", "dbo.Categories");
            DropIndex("dbo.WareHouseCategories", new[] { "WareHouse_WareHouseName" });
            DropIndex("dbo.WareHouseCategories", new[] { "Category_Code" });
            CreateTable(
                "dbo.SupplyPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CategoryCode = c.Int(nullable: false),
                        WareHousesName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryCode, cascadeDelete: true)
                .ForeignKey("dbo.WareHouses", t => t.WareHousesName)
                .Index(t => t.CategoryCode)
                .Index(t => t.WareHousesName);
            
            AddColumn("dbo.Categories", "Amount", c => c.Int());
            DropTable("dbo.WareHouseCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WareHouseCategories",
                c => new
                    {
                        WareHouse_WareHouseName = c.String(nullable: false, maxLength: 200),
                        Category_Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WareHouse_WareHouseName, t.Category_Code });
            
            DropForeignKey("dbo.SupplyPermissions", "WareHousesName", "dbo.WareHouses");
            DropForeignKey("dbo.SupplyPermissions", "CategoryCode", "dbo.Categories");
            DropIndex("dbo.SupplyPermissions", new[] { "WareHousesName" });
            DropIndex("dbo.SupplyPermissions", new[] { "CategoryCode" });
            DropColumn("dbo.Categories", "Amount");
            DropTable("dbo.SupplyPermissions");
            CreateIndex("dbo.WareHouseCategories", "Category_Code");
            CreateIndex("dbo.WareHouseCategories", "WareHouse_WareHouseName");
            AddForeignKey("dbo.WareHouseCategories", "Category_Code", "dbo.Categories", "Code", cascadeDelete: true);
            AddForeignKey("dbo.WareHouseCategories", "WareHouse_WareHouseName", "dbo.WareHouses", "WareHouseName", cascadeDelete: true);
        }
    }
}
