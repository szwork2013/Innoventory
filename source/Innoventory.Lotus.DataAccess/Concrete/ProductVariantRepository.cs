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
    [Export(typeof(IProductVariantRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantRepository : GenericRepository<ProductVariant>, IProductVariantRepository
    {
        public ProductVariant FindById(Guid productVariantId)
        {
            return GetAll().FirstOrDefault(x => x.ProductVariantId == productVariantId);
        }
    }
}
