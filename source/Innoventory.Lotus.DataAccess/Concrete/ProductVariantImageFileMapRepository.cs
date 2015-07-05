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
    [Export(typeof(IProductVariantImageFileMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantImageFileMapRepository : GenericRepository<ProductVariantImageFileMap>, IProductVariantImageFileMapRepository
    {
        public ProductVariantImageFileMap FindById(Guid productVariantImageFileMapId)
        {
            return GetAll().FirstOrDefault(x => x.ProductVariantImageFileMapId == productVariantImageFileMapId);
        }
    }
}
