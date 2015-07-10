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
    [Export(typeof(ISupplierRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SupplierRepository : GenericRepository<Supplier, SupplierViewModel>, ISupplierRepository
    {

        protected override SupplierViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<SupplierViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, SupplierViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SupplierViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<SupplierViewModel> Find(InnoventoryDBContext dbContext, Func<SupplierViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
