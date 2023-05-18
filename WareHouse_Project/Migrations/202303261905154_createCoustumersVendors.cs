namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCoustumersVendors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(nullable: false, maxLength: 128),
                        Fax = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        Mail = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.Phone });
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(nullable: false, maxLength: 128),
                        Fax = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        Mail = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.Phone });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
            DropTable("dbo.Customers");
        }
    }
}
