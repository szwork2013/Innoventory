namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _040815 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductVariants", "PurchaseVolueMeasureId");
            DropColumn("dbo.ProductVariants", "SalesVolumeMeasureId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductVariants", "SalesVolumeMeasureId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductVariants", "PurchaseVolueMeasureId", c => c.Guid(nullable: false));
        }
    }
}
