using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.Business.Abstract
{
    public interface IUserAccountUserRoleMapRepository : IGenericRepository<UserAccountUserRoleMapViewModel>
    {
        List<UserAccountUserRoleMapViewModel> FindByUserId(Guid userId);

        List<UserAccountUserRoleMapViewModel> FindByUserRoleId(Guid userRoleId);

        UserAccountUserRoleMapViewModel FindByUserIdAndUserRoleId(Guid userId, Guid userRoleId);


    }
}
