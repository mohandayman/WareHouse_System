namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SupplyPermissions", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupplyPermissions", "Amount", c => c.String());
        }
    }
}
