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
    [Export(typeof(IProductVariantImageFileMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantImageFileMapRepository : GenericRepository<ProductVariantImageFileMap, ProductVariantImageFileMapViewModel>, IProductVariantImageFileMapRepository
    {
       
        protected override ProductVariantImageFileMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductVariantImageFileMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

      

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

     

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductVariantImageFileMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductVariantImageFileMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductVariantImageFileMapViewModel> Find(InnoventoryDBContext dbContext, Func<ProductVariantImageFileMapViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
