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
    [Export(typeof(IUserAccountUserRoleMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserAccountUserRoleMapRepository : GenericRepository<UserAccountUserRoleMap, UserAccountUserRoleMapViewModel>, 
                                                        IUserAccountUserRoleMapRepository
    {


        public List<UserAccountUserRoleMapViewModel> FindByUserId(Guid userId)
        {
            List<UserAccountUserRoleMapViewModel> result = new List<UserAccountUserRoleMapViewModel>();
            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                result = GetEntities(dbContext).Where(x => x.UserId == userId).ToList();
            }

            return result;
        }

        public List<UserAccountUserRoleMapViewModel> FindByUserRoleId(Guid userRoleId)
        {
            List<UserAccountUserRoleMapViewModel> result = new List<UserAccountUserRoleMapViewModel>();
            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                result = GetEntities(dbContext).Where(x => x.UserRoleId == userRoleId).ToList();
            }

            return result;
        }

        public UserAccountUserRoleMapViewModel FindByUserIdAndUserRoleId(Guid userId, Guid userRoleId)
        {
            UserAccountUserRoleMapViewModel result = null;

            using(InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                result = GetEntities(dbContext).FirstOrDefault(x=>x.UserId == userId && x.UserRoleId == userRoleId);
            }

            return result;
        }
        

        protected override UserAccountUserRoleMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<UserAccountUserRoleMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        
        protected override bool AddEntity(InnoventoryDBContext dbContext, UserAccountUserRoleMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, UserAccountUserRoleMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<UserAccountUserRoleMapViewModel> Find(InnoventoryDBContext dbContext, Func<UserAccountUserRoleMapViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }


        
    }
}
