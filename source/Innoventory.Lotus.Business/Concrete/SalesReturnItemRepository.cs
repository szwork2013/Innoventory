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
    [Export(typeof(ISalesReturnItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesReturnItemRepository : GenericRepository<SalesReturnItem, SalesReturnItemViewModel>, ISalesReturnItemRepository
    {
       
        protected override SalesReturnItemViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesReturnItemViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

  
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        
        protected override bool AddEntity(InnoventoryDBContext dbContext, SalesReturnItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SalesReturnItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesReturnItemViewModel> Find(InnoventoryDBContext dbContext, Func<SalesReturnItemViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
