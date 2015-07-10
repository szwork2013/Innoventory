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
    [Export(typeof(IAttributeValueListRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AttributeValueListRepository : GenericRepository<AttributeValueList, AttributeValueListViewModel>, IAttributeValueListRepository
    {

        protected override AttributeValueListViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<AttributeValueListViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

      
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

      
        protected override bool AddEntity(InnoventoryDBContext dbContext, AttributeValueListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, AttributeValueListViewModel viewModel)
        {
            throw new NotImplementedException();
        }

      

        protected override List<AttributeValueListViewModel> Find(InnoventoryDBContext dbContext, Func<AttributeValueListViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
