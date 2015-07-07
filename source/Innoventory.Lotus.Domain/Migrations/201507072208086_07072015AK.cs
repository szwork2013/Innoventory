namespace Innoventory.Lotus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07072015AK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserAccountUserRoleMaps", "UserId", "dbo.UserAccounts");
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropPrimaryKey("dbo.UserAccounts");
            CreateTable(
                "dbo.CountryAddresses",
                c => new
                    {
                        Country_CountryID = c.Guid(nullable: false),
                        Address_AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_CountryID, t.Address_AddressID })
                .ForeignKey("dbo.Countries", t => t.Country_CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID, cascadeDelete: true)
                .Index(t => t.Country_CountryID)
                .Index(t => t.Address_AddressID);
            
            AddColumn("dbo.UserAccounts", "UserAccountId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserAccounts", "UserAccountId");
            AddForeignKey("dbo.UserAccountUserRoleMaps", "UserId", "dbo.UserAccounts", "UserAccountId", cascadeDelete: true);
            DropColumn("dbo.UserAccounts", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "UserID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.UserAccountUserRoleMaps", "UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.CountryAddresses", "Address_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.CountryAddresses", "Country_CountryID", "dbo.Countries");
            DropIndex("dbo.CountryAddresses", new[] { "Address_AddressID" });
            DropIndex("dbo.CountryAddresses", new[] { "Country_CountryID" });
            DropPrimaryKey("dbo.UserAccounts");
            DropColumn("dbo.UserAccounts", "UserAccountId");
            DropTable("dbo.CountryAddresses");
            AddPrimaryKey("dbo.UserAccounts", "UserID");
            CreateIndex("dbo.Addresses", "CountryId");
            AddForeignKey("dbo.UserAccountUserRoleMaps", "UserId", "dbo.UserAccounts", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CountryId", "dbo.Countries", "CountryID", cascadeDelete: true);
        }
    }
}
