namespace Realtors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountFieldToSales : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Amount");
        }
    }
}
