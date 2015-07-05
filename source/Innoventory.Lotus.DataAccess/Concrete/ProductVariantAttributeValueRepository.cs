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
    [Export(typeof(IProductVariantAttributeValueRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantAttributeValueRepository : GenericRepository<ProductVariantAttributeValue>, IProductVariantAttributeValueRepository
    {
        public ProductVariantAttributeValue FindById(Guid productVariantAttributeValueId)
        {
            return GetAll().FirstOrDefault(x => x.ProductVariantAttributeValueId == productVariantAttributeValueId);
        }
    }
}
