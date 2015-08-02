namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _020815_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "SupplierReference", c => c.String(maxLength: 20));
            AddColumn("dbo.SalesOrders", "ReferenceNo", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesOrders", "ReferenceNo");
            DropColumn("dbo.PurchaseOrders", "SupplierReference");
        }
    }
}
