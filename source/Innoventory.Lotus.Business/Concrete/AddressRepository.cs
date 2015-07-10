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



        protected override AddressViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<AddressViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

    
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

      

        protected override bool AddEntity(InnoventoryDBContext dbContext, AddressViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, AddressViewModel viewModel)
        {
            throw new NotImplementedException();
        }

       
        protected override List<AddressViewModel> Find(InnoventoryDBContext dbContext, Func<AddressViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
