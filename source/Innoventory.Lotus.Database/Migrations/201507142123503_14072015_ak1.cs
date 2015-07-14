namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14072015_ak1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CategorySubCategoryMaps", "CategoryId");
            CreateIndex("dbo.CategorySubCategoryMaps", "SubCategoryId");
            AddForeignKey("dbo.CategorySubCategoryMaps", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.CategorySubCategoryMaps", "SubCategoryId", "dbo.SubCategories", "SubCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategorySubCategoryMaps", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.CategorySubCategoryMaps", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CategorySubCategoryMaps", new[] { "SubCategoryId" });
            DropIndex("dbo.CategorySubCategoryMaps", new[] { "CategoryId" });
        }
    }
}
