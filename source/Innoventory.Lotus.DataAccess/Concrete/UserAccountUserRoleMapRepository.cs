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
        public UserAccountUserRoleMap FindById(Guid userAccountUserRoleMapId)
        {
            return GetAll().FirstOrDefault(x => x.UserAccountUserRoleMapId == userAccountUserRoleMapId);
        }
    }
}
