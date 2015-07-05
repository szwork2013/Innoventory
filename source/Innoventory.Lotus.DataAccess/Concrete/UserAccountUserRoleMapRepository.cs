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
    [Export(typeof(IUserAccountUserRoleMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserAccountUserRoleMapRepository : GenericRepository<UserAccountUserRoleMap>, IUserAccountUserRoleMapRepository
    {
        public UserAccountUserRoleMap FindById(Guid userId)
        {
            return GetAll().FirstOrDefault(x => x.UserId == userId);
        }

        public List<UserAccountUserRoleMap> FindByUserId(Guid userId)
        {
            return GetAll().Where(x => x.UserId == userId).ToList();
        }

        public List<UserAccountUserRoleMap> FindByUserRoleId(Guid userRoleId)
        {
            return GetAll().Where(x => x.UserRoleId == userRoleId).ToList();
        }

        public UserAccountUserRoleMap FindByUserIdAndUserRoleId(Guid userId, Guid userRoleId)
        {
            return GetAll().FirstOrDefault(x => x.UserId == userId && x.UserRoleId == userRoleId);
        }
    }
}
