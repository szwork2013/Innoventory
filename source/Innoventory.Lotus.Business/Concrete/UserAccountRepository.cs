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
    [Export(typeof(IUserAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserAccountRepository : GenericRepository<UserAccount, UserAccountViewModel>, IUserAccountRepository
    {

        protected override UserAccountViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<UserAccountViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, UserAccountViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, UserAccountViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<UserAccountViewModel> Find(InnoventoryDBContext dbContext, Func<UserAccountViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
