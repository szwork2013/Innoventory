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
    [Export(typeof(IAddressRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddressRepository : GenericRepository<Address, AddressViewModel>, IAddressRepository
    {
        public AddressViewModel FindById(Guid addressId)
        {
            return GetAll().FirstOrDefault(x => x.AddressID == addressId);
        }

       
        
    }
}
