namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _010915 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Currencies", "CurrencyCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.Currencies", "CurrencyFullName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "CurrencyFullName", c => c.String(maxLength: 3));
            AlterColumn("dbo.Currencies", "CurrencyCode", c => c.String(maxLength: 3));
        }
    }
}
