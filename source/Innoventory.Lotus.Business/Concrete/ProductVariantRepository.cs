using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IProductVariantRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantRepository : GenericRepository<ProductVariant, ProductVariantViewModel>, IProductVariantRepository
    {

        protected ProductVariant GetDomainEntity(ProductVariantViewModel viewModel)
        {
            ProductVariant productVariant = ObjectMapper.PropertyMap(viewModel, new ProductVariant());

            return productVariant;
        }



        protected override ProductVariantViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            ProductVariant dmProductVariant = entitySet.FirstOrDefault(x => x.ProductVariantId == id);

            ProductVariantViewModel pvVM = new ProductVariantViewModel();

            ProductVariantViewModel productVariantVM = ObjectMapper.PropertyMap(dmProductVariant, pvVM);

            return productVariantVM;

        }

        protected override List<ProductVariantViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            List<ProductVariant> productVariants = entitySet.ToList();

            List<ProductVariantViewModel> retList = new List<ProductVariantViewModel>();

            foreach (ProductVariant productVariant in productVariants)
            {
                ProductVariantViewModel pvVM = new ProductVariantViewModel();


                retList.Add(ObjectMapper.PropertyMap(productVariant, pvVM));

            }

            return retList;
        }

        protected override List<ProductVariantViewModel> Find(InnoventoryDBContext dbContext, Func<ProductVariantViewModel, bool> predicate)
        {

            List<ProductVariantViewModel> productVariants = (GetEntities(dbContext)).Where(predicate).ToList();

            return productVariants;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            //ProductVariantViewModel productVariantVM = GetEntity(dbContext, id);


            ProductVariant productVariant = entitySet.FirstOrDefault(x => x.ProductVariantId == id);

            if (productVariant != null)
            {
                entitySet.Remove(productVariant);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductVariantViewModel viewModel)
        {
            ProductVariant productVariant = GetDomainEntity(viewModel);
            dbContext.ProductVariantSet.Add(productVariant);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductVariantViewModel viewModel)
        {
            DbSet<ProductVariant> entitySet = dbContext.ProductVariantSet;

            ProductVariant productVariant = GetDomainEntity(viewModel);

            entitySet.Attach(productVariant);

            dbContext.Entry(productVariant).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }
    }
}
