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
    [Export(typeof(ICurrencyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrencyRepository : GenericRepository<Currency, CurrencyViewModel>, ICurrencyRepository
    {

        protected override CurrencyViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<CurrencyViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       

        protected override bool AddEntity(InnoventoryDBContext dbContext, CurrencyViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CurrencyViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<CurrencyViewModel> Find(InnoventoryDBContext dbContext, Func<CurrencyViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
