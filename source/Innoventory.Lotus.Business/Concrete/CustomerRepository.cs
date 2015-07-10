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
    [Export(typeof(ICustomerRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerRepository : GenericRepository<Customer, CustomerViewModel>, ICustomerRepository
    {

        protected override CustomerViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<CustomerViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, CustomerViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CustomerViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<CustomerViewModel> Find(InnoventoryDBContext dbContext, Func<CustomerViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
