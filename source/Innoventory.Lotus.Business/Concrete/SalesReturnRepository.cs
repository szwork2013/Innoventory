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
    [Export(typeof(ISalesReturnRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesReturnRepository : GenericRepository<SalesReturn, SalesReturnViewModel>, ISalesReturnRepository
    {

        protected override SalesReturnViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesReturnViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, SalesReturnViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SalesReturnViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<SalesReturnViewModel> Find(InnoventoryDBContext dbContext, Func<SalesReturnViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
