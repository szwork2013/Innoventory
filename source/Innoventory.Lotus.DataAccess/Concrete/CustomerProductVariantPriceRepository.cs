using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
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
