using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IProductVariantAttributeValueRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantAttributeValueRepository : GenericRepository<ProductVariantAttributeValue, ProductVariantAttributeValueViewModel>, IProductVariantAttributeValueRepository
    {
        
        protected override ProductVariantAttributeValueViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductVariantAttributeValueViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

      

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductVariantAttributeValueViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductVariantAttributeValueViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductVariantAttributeValueViewModel> Find(InnoventoryDBContext dbContext, Func<ProductVariantAttributeValueViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
