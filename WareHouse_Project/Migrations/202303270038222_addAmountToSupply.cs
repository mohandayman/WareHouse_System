namespace WareHouse_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAmountToSupply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplyPermissions", "Amount", c => c.String());
            DropColumn("dbo.Categories", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Amount", c => c.Int());
            DropColumn("dbo.SupplyPermissions", "Amount");
        }
    }
}
