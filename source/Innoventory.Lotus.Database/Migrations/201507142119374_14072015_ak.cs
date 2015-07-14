namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14072015_ak : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.ProductVariantImageFileMapImageFiles", new[] { "ProductVariantImageFileMap_ProductVariantId", "ProductVariantImageFileMap_ImageFileId" }, "dbo.ProductVariantImageFileMaps");
            DropForeignKey("dbo.ProductVariantImageFileMapImageFiles", "ImageFile_ImageFileId", "dbo.ImageFiles");
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.ProductVariantImageFileMapImageFiles", new[] { "ProductVariantImageFileMap_ProductVariantId", "ProductVariantImageFileMap_ImageFileId" });
            DropIndex("dbo.ProductVariantImageFileMapImageFiles", new[] { "ImageFile_ImageFileId" });
            CreateIndex("dbo.ProductVariantImageFileMaps", "ImageFileId");
            AddForeignKey("dbo.ProductVariantImageFileMaps", "ImageFileId", "dbo.ImageFiles", "ImageFileId", cascadeDelete: true);
            DropColumn("dbo.Products", "SubCategoryId");
            DropTable("dbo.ProductVariantImageFileMapImageFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductVariantImageFileMapImageFiles",
                c => new
                    {
                        ProductVariantImageFileMap_ProductVariantId = c.Guid(nullable: false),
                        ProductVariantImageFileMap_ImageFileId = c.Guid(nullable: false),
                        ImageFile_ImageFileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductVariantImageFileMap_ProductVariantId, t.ProductVariantImageFileMap_ImageFileId, t.ImageFile_ImageFileId });
            
            AddColumn("dbo.Products", "SubCategoryId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.ProductVariantImageFileMaps", "ImageFileId", "dbo.ImageFiles");
            DropIndex("dbo.ProductVariantImageFileMaps", new[] { "ImageFileId" });
            CreateIndex("dbo.ProductVariantImageFileMapImageFiles", "ImageFile_ImageFileId");
            CreateIndex("dbo.ProductVariantImageFileMapImageFiles", new[] { "ProductVariantImageFileMap_ProductVariantId", "ProductVariantImageFileMap_ImageFileId" });
            CreateIndex("dbo.Products", "SubCategoryId");
            AddForeignKey("dbo.ProductVariantImageFileMapImageFiles", "ImageFile_ImageFileId", "dbo.ImageFiles", "ImageFileId", cascadeDelete: true);
            AddForeignKey("dbo.ProductVariantImageFileMapImageFiles", new[] { "ProductVariantImageFileMap_ProductVariantId", "ProductVariantImageFileMap_ImageFileId" }, "dbo.ProductVariantImageFileMaps", new[] { "ProductVariantId", "ImageFileId" }, cascadeDelete: true);
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "SubCategoryId", cascadeDelete: true);
        }
    }
}
