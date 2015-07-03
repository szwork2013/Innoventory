using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    [Export(typeof(IAttributeValueListRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddressRepository : GenericRepository<Address>, IAttributeValueListRepository
    {
        public Address FindById(Guid addressId)
        {
            return GetAll().FirstOrDefault(x => x.AddressID == addressId);
        }
    }
}
