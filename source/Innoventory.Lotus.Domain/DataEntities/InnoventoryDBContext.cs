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



        public DbSet<Product> ProductSet { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<Address> AddressSet { get; set; }


        public DbSet<Category> CategorySet { get; set; }

        public DbSet<AttributeValueList> AttributeValueListSet { get; set; }

        public DbSet<CategorySubCategoryMap> CategorySubCategoryMapSet { get; set; }

        public DbSet<ProductAttribute> ProductAttributeSet { get; set; }

        public DbSet<ProductVariantAttributeValue> ProductVariantAttributeValueSet { get; set; }

        public DbSet<ProductVariantImageFileMap> ProductVariantImageFileMapSet { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrderSet { get; set; }

        public DbSet<PurchaseOrderItem> PurchaseOrderItemSet { get; set; }

        public DbSet<CategorySubCategoryAttributeMap> CategorySubCategoryAttributeMapSet { get; set; }

        public DbSet<Country> CountrySet { get; set; }

        public DbSet<Customer> CustomerSet { get; set; }

        public DbSet<CustomerProductVariantPrice> CustomerProductVariantPriceSet { get; set; }

        public DbSet<PurchaseReturn> PurchaseReturnSet { get; set; }

        public DbSet<PurchaseReturnItem> PurchaseReturnItemSet { get; set; }

        public DbSet<SalesOrder> SalesOrderSet { get; set; }

        public DbSet<SalesOrderItem> SalesOrderItemSet { get; set; }

        public DbSet<SalesReturn> SalesReturnSet { get; set; }


        public DbSet<SalesReturnItem> SalesReturnItemSet { get; set; }

        public DbSet<SubCategory> SubCategorySet { get; set; }

        public DbSet<Supplier> SupplierSet { get; set; }

        public DbSet<UserAccount> UserAccountSet { get; set; }

        public DbSet<VolumeMeasure> VolumeMeasureSet { get; set; }


        public DbSet<UserRole> UserRoleSet { get; set; }

        public DbSet<UserAccountUserRoleMap> UserAccountUserRoleMapSet { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //For Table Mapping 

            modelBuilder.Entity<ProductVariantAttributeValue>().HasKey(x => new { x.ProductVariantId, x.AttributeValueListId });

            modelBuilder.Entity<ProductVariantImageFileMap>().HasKey(x => new { x.ProductVariantId, x.ImageFileId });

            modelBuilder.Entity<UserAccountUserRoleMap> ().HasKey(x=> new { x.UserId, x.UserRoleId });

            modelBuilder.Entity<ProductVariant>().Property(x => x.AvailableQuantity).HasPrecision(8, 2);

        }
    }
}
