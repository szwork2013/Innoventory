using Innoventory.Lotus.Repository.Abstract;
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

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(IProductAttributeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductAttibuteRepository : GenericRepository<ProductAttribute, ProductAttributeViewModel>, IProductAttributeRepository
    {
        protected ProductAttribute GetDomainEntity(ProductAttributeViewModel viewModel)
        {
            ProductAttribute productattribute = ObjectMapper.PropertyMap(viewModel, new ProductAttribute());

            return productattribute;
        }

        protected override ProductAttributeViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<ProductAttribute> entitySet = dbContext.ProductAttributeSet;

            ProductAttribute dmProductAttribute = entitySet.FirstOrDefault(x => x.ProductAttributeId == id);

            ProductAttributeViewModel paVM = new ProductAttributeViewModel();

            ProductAttributeViewModel productAttributeVM = ObjectMapper.PropertyMap(dmProductAttribute, paVM);

            return productAttributeVM;
        }

        protected override List<ProductAttributeViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<ProductAttribute> entitySet = dbContext.ProductAttributeSet;

            List<ProductAttribute> productAttributes = entitySet.OrderBy(x => x.AttributeName).ToList();

            List<ProductAttributeViewModel> retList = new List<ProductAttributeViewModel>();

            foreach (var productAttribute in productAttributes)
            {
                var pavm = new ProductAttributeViewModel();

                retList.Add(ObjectMapper.PropertyMap(productAttribute, pavm));

            }

            return retList;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<ProductAttribute> entitySet = dbContext.ProductAttributeSet;

            //ProductAttributeViewModel productattributeVM = GetEntity(dbContext, id);


            ProductAttribute productattribute = entitySet.FirstOrDefault(x => x.ProductAttributeId == id);

            if (productattribute != null)
            {
                entitySet.Remove(productattribute);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductAttributeViewModel viewModel)
        {
            ProductAttribute productattribute = GetDomainEntity(viewModel);
            dbContext.ProductAttributeSet.Add(productattribute);

            dbContext.SaveChanges();
            return true;

        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductAttributeViewModel viewModel)
        {
            DbSet<ProductAttribute> entitySet = dbContext.ProductAttributeSet;

            ProductAttribute productattribute = GetDomainEntity(viewModel);

            entitySet.Attach(productattribute);

            dbContext.Entry(productattribute).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
        }

        protected override List<ProductAttributeViewModel> Find(InnoventoryDBContext dbContext, Func<ProductAttributeViewModel, bool> predicate)
        {
            List<ProductAttributeViewModel> productAttributes = (GetEntities(dbContext)).Where(predicate).ToList();

            return productAttributes;
        }
    }
}
