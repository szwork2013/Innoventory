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
    [Export(typeof(ICustomerRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public Customer FindById(Guid customerId)
        {
            return GetAll().FirstOrDefault(x => x.CustomerId == customerId);
        }
    }
}
