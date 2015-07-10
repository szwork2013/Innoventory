namespace Innoventory.Lotus.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        AddressMapId = c.Guid(nullable: false),
                        AddressType = c.Short(nullable: false),
                        AddressLine1 = c.String(maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 60),
                        PostCode = c.String(maxLength: 12),
                        State = c.String(maxLength: 100),
                        CountryId = c.Guid(nullable: false),
                        DefaultAddress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Guid(nullable: false),
                        CountryName = c.String(maxLength: 50),
                        CountryCode = c.String(maxLength: 5),
                        ISDCode = c.String(maxLength: 5),
                        CurrencyID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.AttributeValueLists",
                c => new
                    {
                        AttributeValueListId = c.Guid(nullable: false),
                        CategorySubCategoryAttributeMapID = c.Guid(nullable: false),
                        AttributeValue = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AttributeValueListId)
                .ForeignKey("dbo.CategorySubCategoryAttributeMaps", t => t.CategorySubCategoryAttributeMapID, cascadeDelete: true)
                .Index(t => t.CategorySubCategoryAttributeMapID);
            
            CreateTable(
                "dbo.CategorySubCategoryAttributeMaps",
                c => new
                    {
                        CategorySubCategoryAttributeMapID = c.Guid(nullable: false),
                        CategorySubCategoryMapId = c.Guid(nullable: false),
                        ProductAttributeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CategorySubCategoryAttributeMapID)
                .ForeignKey("dbo.CategorySubCategoryMaps", t => t.CategorySubCategoryMapId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttributes", t => t.ProductAttributeId, cascadeDelete: true)
                .Index(t => t.CategorySubCategoryMapId)
                .Index(t => t.ProductAttributeId);
            
            CreateTable(
                "dbo.CategorySubCategoryMaps",
                c => new
                    {
                        CategorySubCategoryMapId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        SubCategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CategorySubCategoryMapId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.CategorySubCategoryMaps", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductAttributes",
                c => new
                    {
                        ProductAttributeId = c.Guid(nullable: false),
                        AttributeName = c.String(maxLength: 100),
                        AttributeDescription = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ProductAttributeId);
            
            CreateTable(
                "dbo.ProductVariantAttributeValues",
                c => new
                    {
                        ProductVariantId = c.Guid(nullable: false),
                        AttributeValueListId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductVariantId, t.AttributeValueListId })
                .ForeignKey("dbo.AttributeValueLists", t => t.AttributeValueListId, cascadeDelete: true)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .Index(t => t.ProductVariantId)
                .Index(t => t.AttributeValueListId);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageFileId = c.Guid(nullable: false),
                        ImageUrl = c.String(maxLength: 300),
                        ImageType = c.String(maxLength: 100),
                        ImageData = c.Binary(),
                        Product_ProductId = c.Guid(),
                        ProductVariant_ProductVariantId = c.Guid(),
                    })
                .PrimaryKey(t => t.ImageFileId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariant_ProductVariantId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.ProductVariant_ProductVariantId);
            
            CreateTable(
                "dbo.ProductVariantImageFileMaps",
                c => new
                    {
                        ProductVariantId = c.Guid(nullable: false),
                        ImageFileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductVariantId, t.ImageFileId })
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .Index(t => t.ProductVariantId);
            
            CreateTable(
                "dbo.CustomerProductVariantPrices",
                c => new
                    {
                        CustomerProductVariantPriceId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ProductVariantId = c.Guid(nullable: false),
                        PricingType = c.Int(nullable: false),
                        PricingValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CustomerProductVariantPriceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductVariantId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Guid(nullable: false),
                        CustomerName = c.String(maxLength: 100),
                        CustomerContactNo = c.String(maxLength: 50),
                        CustomerEmailId = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrderId = c.Guid(nullable: false),
                        PurchaseOrderDate = c.DateTime(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Taxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerId = c.Guid(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.SupplierId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        PurchaseOrderItemId = c.Guid(nullable: false),
                        PurchaseOrderId = c.Guid(nullable: false),
                        ProductVariantId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseReturn_PurchaseReturnId = c.Guid(),
                    })
                .PrimaryKey(t => t.PurchaseOrderItemId)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseReturns", t => t.PurchaseReturn_PurchaseReturnId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductVariantId)
                .Index(t => t.PurchaseReturn_PurchaseReturnId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Guid(nullable: false),
                        SupplierName = c.String(maxLength: 100),
                        SupplierContactNo = c.String(maxLength: 50),
                        SupplierEmailId = c.String(maxLength: 200),
                        CurrencyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyID = c.Guid(nullable: false),
                        CurrencyCode = c.String(maxLength: 3),
                        CurrencySymbol = c.String(maxLength: 3),
                        CurrencyFullName = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.PurchaseReturnItems",
                c => new
                    {
                        PurchaseReturnItemId = c.Guid(nullable: false),
                        PurchaseReturnId = c.Guid(nullable: false),
                        ProductVariantId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseReturnItemId)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseReturns", t => t.PurchaseReturnId, cascadeDelete: true)
                .Index(t => t.PurchaseReturnId)
                .Index(t => t.ProductVariantId);
            
            CreateTable(
                "dbo.PurchaseReturns",
                c => new
                    {
                        PurchaseReturnId = c.Guid(nullable: false),
                        PurchaseOrderDate = c.DateTime(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseReturnId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                    {
                        SalesOrderItemId = c.Guid(nullable: false),
                        SalesOrderId = c.Guid(nullable: false),
                        ProductVariantId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesReturn_SalesReturnId = c.Guid(),
                    })
                .PrimaryKey(t => t.SalesOrderItemId)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .ForeignKey("dbo.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
                .ForeignKey("dbo.SalesReturns", t => t.SalesReturn_SalesReturnId)
                .Index(t => t.SalesOrderId)
                .Index(t => t.ProductVariantId)
                .Index(t => t.SalesReturn_SalesReturnId);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        SalesOrderId = c.Guid(nullable: false),
                        SaleOrderDate = c.DateTime(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Taxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesOrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SalesReturnItems",
                c => new
                    {
                        SalesReturnItemId = c.Guid(nullable: false),
                        SalesReturnId = c.Guid(nullable: false),
                        ProductVariantId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesReturnItemId)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariantId, cascadeDelete: true)
                .ForeignKey("dbo.SalesReturns", t => t.SalesReturnId, cascadeDelete: true)
                .Index(t => t.SalesReturnId)
                .Index(t => t.ProductVariantId);
            
            CreateTable(
                "dbo.SalesReturns",
                c => new
                    {
                        SalesReturnId = c.Guid(nullable: false),
                        SaleReturnDate = c.DateTime(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Taxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesReturnId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        SecretQuestionID = c.Guid(nullable: false),
                        SecretAnswer = c.String(),
                        UserStatusID = c.Short(nullable: false),
                        Contact1 = c.String(),
                        Contact2 = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserAccountUserRoleMaps",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserRoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.UserRoleId })
                .ForeignKey("dbo.UserAccounts", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Guid(nullable: false),
                        RoleName = c.String(maxLength: 20),
                        RoleDescription = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.VolumeMeasures",
                c => new
                    {
                        VolumeMeasureId = c.Guid(nullable: false),
                        VolumeMeasureName = c.String(maxLength: 50),
                        ShortName = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.VolumeMeasureId);
            
            CreateTable(
                "dbo.ProductVariantImageFileMapImageFiles",
                c => new
                    {
                        ProductVariantImageFileMap_ProductVariantId = c.Guid(nullable: false),
                        ProductVariantImageFileMap_ImageFileId = c.Guid(nullable: false),
                        ImageFile_ImageFileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductVariantImageFileMap_ProductVariantId, t.ProductVariantImageFileMap_ImageFileId, t.ImageFile_ImageFileId })
                .ForeignKey("dbo.ProductVariantImageFileMaps", t => new { t.ProductVariantImageFileMap_ProductVariantId, t.ProductVariantImageFileMap_ImageFileId }, cascadeDelete: true)
                .ForeignKey("dbo.ImageFiles", t => t.ImageFile_ImageFileId, cascadeDelete: true)
                .Index(t => new { t.ProductVariantImageFileMap_ProductVariantId, t.ProductVariantImageFileMap_ImageFileId })
                .Index(t => t.ImageFile_ImageFileId);
            
            AddColumn("dbo.Products", "SalesVolumeMeasureId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "PurchaseVolumeMeasureId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "ModifiedBy", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductVariants", "PurchaseUnitVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductVariants", "SalesUnitVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductVariants", "ReorderPoint", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.ProductVariants", "ReorderQuantity", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.ProductVariants", "LastSupplierId", c => c.Guid());
            AddColumn("dbo.ProductVariants", "ImageFileId", c => c.Guid());
            AddColumn("dbo.ProductVariants", "AvailableQuantity", c => c.Decimal(nullable: false, precision: 8, scale: 2));
            AddColumn("dbo.ProductVariants", "ModifiedBy", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductVariants", "ModifiedOn", c => c.DateTime(nullable: false));
            CreateIndex("dbo.SubCategories", "SubCategoryId");
            AddForeignKey("dbo.SubCategories", "SubCategoryId", "dbo.CategorySubCategoryMaps", "CategorySubCategoryMapId");
            DropColumn("dbo.Products", "ReorderPoint");
            DropColumn("dbo.Products", "ReorderQuantity");
            DropColumn("dbo.Products", "UnitId");
            DropColumn("dbo.Products", "LastModifiedBy");
            DropColumn("dbo.Products", "LastModifiedOn");
            DropColumn("dbo.ProductVariants", "PurchaseOrderVolume");
            DropColumn("dbo.ProductVariants", "SalesOrderVolume");
            DropColumn("dbo.ProductVariants", "LastVendorId");
            DropColumn("dbo.ProductVariants", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductVariants", "ImageId", c => c.Guid());
            AddColumn("dbo.ProductVariants", "LastVendorId", c => c.Guid());
            AddColumn("dbo.ProductVariants", "SalesOrderVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductVariants", "PurchaseOrderVolume", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "LastModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "LastModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UnitId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "ReorderQuantity", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "ReorderPoint", c => c.Decimal(precision: 18, scale: 2));
            DropForeignKey("dbo.UserAccountUserRoleMaps", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserAccountUserRoleMaps", "UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.SalesReturnItems", "SalesReturnId", "dbo.SalesReturns");
            DropForeignKey("dbo.SalesOrderItems", "SalesReturn_SalesReturnId", "dbo.SalesReturns");
            DropForeignKey("dbo.SalesReturns", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesReturnItems", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesOrderItems", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.PurchaseReturnItems", "PurchaseReturnId", "dbo.PurchaseReturns");
            DropForeignKey("dbo.PurchaseReturns", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseReturn_PurchaseReturnId", "dbo.PurchaseReturns");
            DropForeignKey("dbo.PurchaseReturnItems", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.CustomerProductVariantPrices", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.CustomerProductVariantPrices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderItems", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.ProductVariantAttributeValues", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.ProductVariantImageFileMaps", "ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.ProductVariantImageFileMapImageFiles", "ImageFile_ImageFileId", "dbo.ImageFiles");
            DropForeignKey("dbo.ProductVariantImageFileMapImageFiles", new[] { "ProductVariantImageFileMap_ProductVariantId", "ProductVariantImageFileMap_ImageFileId" }, "dbo.ProductVariantImageFileMaps");
            DropForeignKey("dbo.ImageFiles", "ProductVariant_ProductVariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.ImageFiles", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVariantAttributeValues", "AttributeValueListId", "dbo.AttributeValueLists");
            DropForeignKey("dbo.AttributeValueLists", "CategorySubCategoryAttributeMapID", "dbo.CategorySubCategoryAttributeMaps");
            DropForeignKey("dbo.CategorySubCategoryAttributeMaps", "ProductAttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.CategorySubCategoryAttributeMaps", "CategorySubCategoryMapId", "dbo.CategorySubCategoryMaps");
            DropForeignKey("dbo.SubCategories", "SubCategoryId", "dbo.CategorySubCategoryMaps");
            DropForeignKey("dbo.Categories", "CategoryId", "dbo.CategorySubCategoryMaps");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.ProductVariantImageFileMapImageFiles", new[] { "ImageFile_ImageFileId" });
            DropIndex("dbo.ProductVariantImageFileMapImageFiles", new[] { "ProductVariantImageFileMap_ProductVariantId", "ProductVariantImageFileMap_ImageFileId" });
            DropIndex("dbo.UserAccountUserRoleMaps", new[] { "UserRoleId" });
            DropIndex("dbo.UserAccountUserRoleMaps", new[] { "UserId" });
            DropIndex("dbo.SalesReturns", new[] { "CustomerId" });
            DropIndex("dbo.SalesReturnItems", new[] { "ProductVariantId" });
            DropIndex("dbo.SalesReturnItems", new[] { "SalesReturnId" });
            DropIndex("dbo.SalesOrders", new[] { "CustomerId" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesReturn_SalesReturnId" });
            DropIndex("dbo.SalesOrderItems", new[] { "ProductVariantId" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrderId" });
            DropIndex("dbo.PurchaseReturns", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseReturnItems", new[] { "ProductVariantId" });
            DropIndex("dbo.PurchaseReturnItems", new[] { "PurchaseReturnId" });
            DropIndex("dbo.Suppliers", new[] { "CurrencyId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseReturn_PurchaseReturnId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "ProductVariantId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "Customer_CustomerId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.CustomerProductVariantPrices", new[] { "ProductVariantId" });
            DropIndex("dbo.CustomerProductVariantPrices", new[] { "CustomerId" });
            DropIndex("dbo.ProductVariantImageFileMaps", new[] { "ProductVariantId" });
            DropIndex("dbo.ImageFiles", new[] { "ProductVariant_ProductVariantId" });
            DropIndex("dbo.ImageFiles", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductVariantAttributeValues", new[] { "AttributeValueListId" });
            DropIndex("dbo.ProductVariantAttributeValues", new[] { "ProductVariantId" });
            DropIndex("dbo.SubCategories", new[] { "SubCategoryId" });
            DropIndex("dbo.Categories", new[] { "CategoryId" });
            DropIndex("dbo.CategorySubCategoryAttributeMaps", new[] { "ProductAttributeId" });
            DropIndex("dbo.CategorySubCategoryAttributeMaps", new[] { "CategorySubCategoryMapId" });
            DropIndex("dbo.AttributeValueLists", new[] { "CategorySubCategoryAttributeMapID" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropColumn("dbo.ProductVariants", "ModifiedOn");
            DropColumn("dbo.ProductVariants", "ModifiedBy");
            DropColumn("dbo.ProductVariants", "AvailableQuantity");
            DropColumn("dbo.ProductVariants", "ImageFileId");
            DropColumn("dbo.ProductVariants", "LastSupplierId");
            DropColumn("dbo.ProductVariants", "ReorderQuantity");
            DropColumn("dbo.ProductVariants", "ReorderPoint");
            DropColumn("dbo.ProductVariants", "SalesUnitVolume");
            DropColumn("dbo.ProductVariants", "PurchaseUnitVolume");
            DropColumn("dbo.Products", "ModifiedOn");
            DropColumn("dbo.Products", "ModifiedBy");
            DropColumn("dbo.Products", "PurchaseVolumeMeasureId");
            DropColumn("dbo.Products", "SalesVolumeMeasureId");
            DropTable("dbo.ProductVariantImageFileMapImageFiles");
            DropTable("dbo.VolumeMeasures");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserAccountUserRoleMaps");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.SalesReturns");
            DropTable("dbo.SalesReturnItems");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderItems");
            DropTable("dbo.PurchaseReturns");
            DropTable("dbo.PurchaseReturnItems");
            DropTable("dbo.Currencies");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PurchaseOrderItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerProductVariantPrices");
            DropTable("dbo.ProductVariantImageFileMaps");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.ProductVariantAttributeValues");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Categories");
            DropTable("dbo.CategorySubCategoryMaps");
            DropTable("dbo.CategorySubCategoryAttributeMaps");
            DropTable("dbo.AttributeValueLists");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}
