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

       

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }
        

        
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
