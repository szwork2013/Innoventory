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
