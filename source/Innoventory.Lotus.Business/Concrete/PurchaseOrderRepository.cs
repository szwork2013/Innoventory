using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
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
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder, PurchaseOrderViewModel>, IPurchaseOrderRepository
    {

        protected override PurchaseOrderViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<PurchaseOrderViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

      
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

      
        protected override bool AddEntity(InnoventoryDBContext dbContext, PurchaseOrderViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, PurchaseOrderViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<PurchaseOrderViewModel> Find(InnoventoryDBContext dbContext, Func<PurchaseOrderViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
