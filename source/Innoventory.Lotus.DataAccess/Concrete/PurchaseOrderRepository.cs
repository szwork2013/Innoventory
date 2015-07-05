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
    [Export(typeof(IPurchaseOrderRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrder FindById(Guid purchaseOrderId)
        {
            return GetAll().FirstOrDefault(x => x.PurchaseOrderId == purchaseOrderId);
        }
    }
}
