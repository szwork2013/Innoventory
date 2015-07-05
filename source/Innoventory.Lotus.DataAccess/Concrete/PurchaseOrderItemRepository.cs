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
    [Export(typeof(IPurchaseOrderItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PurchaseOrderItemRepository : GenericRepository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        public PurchaseOrderItem FindById(Guid purchaseOrderItemId)
        {
            return GetAll().FirstOrDefault(x => x.PurchaseOrderItemId == purchaseOrderItemId);
        }
    }
}
