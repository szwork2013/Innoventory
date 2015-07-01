using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public Address FindById(Guid addressId)
        {
            return GetAll().FirstOrDefault(x => x.AddressID == addressId);
        }
    }
}
