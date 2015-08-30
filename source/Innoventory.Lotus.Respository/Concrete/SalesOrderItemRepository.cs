using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ISalesOrderItemRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesOrderItemRepository : GenericRepository<SalesOrderItem, SalesOrderItemViewModel>, ISalesOrderItemRepository
    {
      
        protected override SalesOrderItemViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesOrderItemViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

     

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

      

        protected override bool AddEntity(InnoventoryDBContext dbContext, SalesOrderItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SalesOrderItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesOrderItemViewModel> Find(InnoventoryDBContext dbContext, Func<SalesOrderItemViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
