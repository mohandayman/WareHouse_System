namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCategoryAndReletion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        unit = c.String(nullable: false, maxLength: 50,defaultValue: "Kg"),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.WareHouseCategories",
                c => new
                    {
                        WareHouse_WareHouseName = c.String(nullable: false, maxLength: 200),
                        Category_Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WareHouse_WareHouseName, t.Category_Code })
                .ForeignKey("dbo.WareHouses", t => t.WareHouse_WareHouseName, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Code, cascadeDelete: true)
                .Index(t => t.WareHouse_WareHouseName)
                .Index(t => t.Category_Code);
            
            AlterColumn("dbo.WareHouses", "WareHouseAddress", c => c.String(nullable: false));
            AlterColumn("dbo.WareHouses", "MangerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WareHouseCategories", "Category_Code", "dbo.Categories");
            DropForeignKey("dbo.WareHouseCategories", "WareHouse_WareHouseName", "dbo.WareHouses");
            DropIndex("dbo.WareHouseCategories", new[] { "Category_Code" });
            DropIndex("dbo.WareHouseCategories", new[] { "WareHouse_WareHouseName" });
            AlterColumn("dbo.WareHouses", "MangerName", c => c.String());
            AlterColumn("dbo.WareHouses", "WareHouseAddress", c => c.String());
            DropTable("dbo.WareHouseCategories");
            DropTable("dbo.Categories");
        }
    }
}
