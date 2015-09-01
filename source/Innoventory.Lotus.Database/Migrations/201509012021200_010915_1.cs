namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _010915_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Suppliers", new[] { "CurrencyId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Suppliers", "CurrencyId");
            AddForeignKey("dbo.Suppliers", "CurrencyId", "dbo.Currencies", "CurrencyID", cascadeDelete: true);
        }
    }
}
