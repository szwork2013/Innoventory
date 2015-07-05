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
    [Export(typeof(IUserAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserAccountRepository : GenericRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccount FindById(Guid userAccountId)
        {
            return GetAll().FirstOrDefault(x => x.UserAccountId == userAccountId);
        }
    }
}
