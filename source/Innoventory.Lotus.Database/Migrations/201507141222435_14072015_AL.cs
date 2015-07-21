namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14072015_AL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "CategoryId", "dbo.CategorySubCategoryMaps");
            DropForeignKey("dbo.SubCategories", "SubCategoryId", "dbo.CategorySubCategoryMaps");
            DropIndex("dbo.Categories", new[] { "CategoryId" });
            DropIndex("dbo.SubCategories", new[] { "SubCategoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SubCategories", "SubCategoryId");
            CreateIndex("dbo.Categories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "SubCategoryId", "dbo.CategorySubCategoryMaps", "CategorySubCategoryMapId");
            AddForeignKey("dbo.Categories", "CategoryId", "dbo.CategorySubCategoryMaps", "CategorySubCategoryMapId");
        }
    }
}
