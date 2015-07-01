using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class InnoventoryDBContext : DbContext
    {
        public InnoventoryDBContext()
            : base("name=InnoventoryDBcontext")
        {

        }



        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<Address> Addresses { get; set; }


        public DbSet<Category> Categories { get; set; }

        public DbSet<AttributeValueList> AttributeValueLists { get; set; }

        public DbSet<CategorySubCategoryMap> CategorySubCategoryMaps { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<ProductVariantAttributeValue> ProductVariantAttributeValues { get; set; }

        public DbSet<ProductVariantImageFileMap> ProductVariantImageFileMaps { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public DbSet<CategorySubCategoryAttributeMap> CategorySubCategoryAttributeMaps { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerProductVariantPrice> CustomerProductVariantPrices { get; set; }

        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }

        public DbSet<PurchaseReturnItem> PurchaseReturnItems { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

        public DbSet<SalesReturn> SalesReturns { get; set; }


        public DbSet<SalesReturnItem> SalesReturnItems { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<VolumeMeasure> VolumeMeasurs { get; set; }


        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserAccountUserRoleMap> UserAccountUserRoleMaps { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //For Table Mapping 

            modelBuilder.Entity<ProductVariantAttributeValue>().HasKey(x => new { x.ProductVariantId, x.AttributeValueListId });

            modelBuilder.Entity<ProductVariantImageFileMap>().HasKey(x => new { x.ProductVariantId, x.ImageFileId });

            modelBuilder.Entity<ProductVariant>().Property(x => x.AvailableQuantity).HasPrecision(8, 2);

         


        }
    }
}
