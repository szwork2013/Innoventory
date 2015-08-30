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
    [Export(typeof(ISalesOrderRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesOrderRepository : GenericRepository<SalesOrder, SalesOrderViewModel>, ISalesOrderRepository
    {
      
        protected override SalesOrderViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesOrderViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, SalesOrderViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SalesOrderViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesOrderViewModel> Find(InnoventoryDBContext dbContext, Func<SalesOrderViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
