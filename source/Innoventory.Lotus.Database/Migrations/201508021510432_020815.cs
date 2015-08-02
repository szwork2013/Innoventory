namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _020815 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttributeValueLists", "CategoryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.AttributeValueLists", "CategoryId");
            AddForeignKey("dbo.AttributeValueLists", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.PurchaseOrderItems", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrderItems", "Unit", c => c.Guid(nullable: false));
            DropForeignKey("dbo.AttributeValueLists", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AttributeValueLists", new[] { "CategoryId" });
            DropColumn("dbo.AttributeValueLists", "CategoryId");
        }
    }
}
