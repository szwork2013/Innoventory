namespace Innoventory.Lotus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductName = c.String(maxLength: 200),
                        ItemType = c.Int(nullable: false),
                        Description = c.String(),
                        Remarks = c.String(),
                        SubCategoryId = c.Guid(nullable: false),
                        ReorderPoint = c.Decimal(precision: 18, scale: 2),
                        ReorderQuantity = c.Decimal(precision: 18, scale: 2),
                        UnitId = c.Guid(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        ImageId = c.Guid(),
                        SalesOrderUnitId = c.Guid(nullable: false),
                        PurchaseOrderUnitId = c.Guid(nullable: false),
                        CategorySubCategoryMapId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        ProductVariantId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        BarCode = c.String(maxLength: 500),
                        PurchaseOrderVolume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesOrderVolume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CaseLength = c.Decimal(precision: 18, scale: 2),
                        CaseWidth = c.Decimal(precision: 18, scale: 2),
                        CaseHeight = c.Decimal(precision: 18, scale: 2),
                        CaseWeight = c.Decimal(precision: 18, scale: 2),
                        ProductLength = c.Decimal(precision: 18, scale: 2),
                        ProductWidth = c.Decimal(precision: 18, scale: 2),
                        ProductHeight = c.Decimal(precision: 18, scale: 2),
                        ProductWeight = c.Decimal(precision: 18, scale: 2),
                        LastVendorId = c.Guid(),
                        IsSellable = c.Boolean(nullable: false),
                        IsPurchaseable = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ImageId = c.Guid(),
                        SKUCode = c.String(),
                        LastPurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShelfPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionId = c.Guid(),
                        ProductVariantType = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProductVariantId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Guid(nullable: false),
                        SubCategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductVariants", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Products");
        }
    }
}
