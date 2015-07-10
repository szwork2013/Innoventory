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
    [Export(typeof(IUserRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRoleRepository : GenericRepository<UserRole, UserRoleViewModel>, IUserRoleRepository
    {

        protected override UserRoleViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<UserRoleViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

      

        protected override bool AddEntity(InnoventoryDBContext dbContext, UserRoleViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, UserRoleViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<UserRoleViewModel> Find(InnoventoryDBContext dbContext, Func<UserRoleViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
