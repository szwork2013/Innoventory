using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ICustomerProductVariantPriceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerProductVariantPriceRepository : GenericRepository<CustomerProductVariantPrice, CustomerProductVariantPriceViewModel>, 
                                                            ICustomerProductVariantPriceRepository
    {

        protected override CustomerProductVariantPriceViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<CustomerProductVariantPriceViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, CustomerProductVariantPriceViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CustomerProductVariantPriceViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<CustomerProductVariantPriceViewModel> Find(InnoventoryDBContext dbContext, Func<CustomerProductVariantPriceViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
