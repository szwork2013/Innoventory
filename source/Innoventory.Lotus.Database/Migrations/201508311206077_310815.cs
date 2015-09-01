namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _310815 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SalesOrderItems", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesOrderItems", "Unit", c => c.Guid(nullable: false));
        }
    }
}
