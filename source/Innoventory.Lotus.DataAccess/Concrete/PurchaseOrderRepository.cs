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
