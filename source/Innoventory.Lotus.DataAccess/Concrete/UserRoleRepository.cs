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
    [Export(typeof(IUserRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRole FindById(Guid userRoleId)
        {
            return GetAll().FirstOrDefault(x => x.UserRoleId == userRoleId);
        }
    }
}
