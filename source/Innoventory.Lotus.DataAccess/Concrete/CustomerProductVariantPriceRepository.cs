using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    [Export(typeof(ICustomerProductVariantPriceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerProductVariantPriceRepository : GenericRepository<CustomerProductVariantPrice>, ICustomerProductVariantPriceRepository
    {
        public CustomerProductVariantPrice FindById(Guid customerProductVariantPriceId)
        {
            return GetAll().FirstOrDefault(x => x.CustomerProductVariantPriceId == customerProductVariantPriceId);
        }
    }
}
