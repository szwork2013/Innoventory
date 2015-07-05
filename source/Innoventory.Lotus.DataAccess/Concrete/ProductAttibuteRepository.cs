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
    [Export(typeof(IProductAttibuteRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductAttibuteRepository : GenericRepository<ProductAttribute>, IProductAttibuteRepository
    {
        public ProductAttribute FindById(Guid productAttributeId)
        {
            return GetAll().FirstOrDefault(x => x.ProductAttributeId == productAttributeId);
        }
    }
}
