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
    [Export(typeof(IPurchaseOrderItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PurchaseOrderItemRepository : GenericRepository<PurchaseOrderItem, PurchaseOrderItemViewModel>, IPurchaseOrderItemRepository
    {
       
        protected override PurchaseOrderItemViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<PurchaseOrderItemViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       

        protected override bool AddEntity(InnoventoryDBContext dbContext, PurchaseOrderItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, PurchaseOrderItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<PurchaseOrderItemViewModel> Find(InnoventoryDBContext dbContext, Func<PurchaseOrderItemViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
