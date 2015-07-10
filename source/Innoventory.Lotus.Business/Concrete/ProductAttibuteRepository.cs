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
    [Export(typeof(IProductAttibuteRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductAttibuteRepository : GenericRepository<ProductAttribute, ProductAttributeViewModel>, IProductAttibuteRepository
    {
        protected override ProductAttributeViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductAttributeViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

      

        protected override bool AddEntity(InnoventoryDBContext dbContext, ProductAttributeViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, ProductAttributeViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<ProductAttributeViewModel> Find(InnoventoryDBContext dbContext, Func<ProductAttributeViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
