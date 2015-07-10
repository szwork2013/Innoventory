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
    [Export(typeof(IProductVariantRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantRepository : GenericRepository<ProductVariant, ProductVariantViewModel>, IProductVariantRepository
    {
       
        protected override ProductVariantViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductVariantViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

           

       
               

        protected override List<ProductVariantViewModel> Find(InnoventoryDBContext dbContext, Func<ProductVariantViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductVariantViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductVariantViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
