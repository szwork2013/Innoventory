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

        public DbSet<CategorySubCategoryAttributeMap> CategorySubCategoryAttributeMaps { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerProductVariantPrice> CustomerProductVariantPrices{ get; set; }

        

        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        ////For Table Mapping 
            
        //    modelBuilder.Entity<Budget>().ToTable("tblBudget");

        ////For Preventing Table Creation
        //    modelBuilder.Ignore<UserAccount>();


        //    //For multiple keys
        //    modelBuilder.Entity<VoucherDetail>().HasKey(x => new { x.VoucherHeaderID, x.VoucherDetailID });
            
        //    base.OnModelCreating(modelBuilder);


        //}
    }
}
