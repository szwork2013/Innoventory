using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Repository.Abstract
{
    public interface ICustomerRepository : IGenericRepository<CustomerViewModel>
    {
        FindResult<CustomerViewModel> SearchCustomer(string searchString);
    }
}
