using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Abstract
{
    public interface IUserAccountUserRoleMapRepository : IGenericRepository<UserAccountUserRoleMap>
    {
        List<UserAccountUserRoleMap> FindByUserId(Guid userId);

        List<UserAccountUserRoleMap> FindByUserRoleId(Guid userRoleId);

        UserAccountUserRoleMap FindByUserIdAndUserRoleId(Guid userId, Guid userRoleId);


    }
}
