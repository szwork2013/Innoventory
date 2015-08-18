namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18082015 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductVariants", "UnitVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "VolumeMeasureId", c => c.Guid(nullable: false));
            DropColumn("dbo.ProductVariants", "PurchaseVolume");
            DropColumn("dbo.ProductVariants", "SalesVolume");
            DropColumn("dbo.Products", "SalesVolumeMeasureId");
            DropColumn("dbo.Products", "PurchaseVolumeMeasureId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PurchaseVolumeMeasureId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "SalesVolumeMeasureId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductVariants", "SalesVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductVariants", "PurchaseVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "VolumeMeasureId");
            DropColumn("dbo.ProductVariants", "UnitVolume");
        }
    }
}
