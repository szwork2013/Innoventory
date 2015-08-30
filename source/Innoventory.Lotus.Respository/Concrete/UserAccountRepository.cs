using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(IUserAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserAccountRepository : GenericRepository<UserAccount, UserAccountViewModel>, IUserAccountRepository
    {

        protected UserAccount GetDomainEntity(UserAccountViewModel viewModel)
        {
            UserAccount userAccount = ObjectMapper.PropertyMap(viewModel, new UserAccount());

            return userAccount;
        }



        protected override UserAccountViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<UserAccount> entitySet = dbContext.UserAccountSet;

            UserAccount dmUserAccount = entitySet.FirstOrDefault(x => x.UserAccountId == id);

            UserAccountViewModel useracctVM = new UserAccountViewModel();

            UserAccountViewModel userAccountVM = ObjectMapper.PropertyMap(dmUserAccount, useracctVM);

            return userAccountVM;

        }

        protected override List<UserAccountViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<UserAccount> entitySet = dbContext.UserAccountSet;

            List<UserAccount> userAccounts = entitySet.ToList();

            List<UserAccountViewModel> retList = new List<UserAccountViewModel>();

            foreach (UserAccount userAccount in userAccounts)
            {
                UserAccountViewModel useracctVM = new UserAccountViewModel();


                retList.Add(ObjectMapper.PropertyMap(userAccount, useracctVM));

            }

            return retList;
        }

        protected override List<UserAccountViewModel> Find(InnoventoryDBContext dbContext, Func<UserAccountViewModel, bool> predicate)
        {

            List<UserAccountViewModel> userAccounts = (GetEntities(dbContext)).Where(predicate).ToList();

            return userAccounts;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<UserAccount> entitySet = dbContext.UserAccountSet;

            //UserAccountViewModel userAccountVM = GetEntity(dbContext, id);


            UserAccount userAccount = entitySet.FirstOrDefault(x => x.UserAccountId == id);

            if (userAccount != null)
            {
                entitySet.Remove(userAccount);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, UserAccountViewModel viewModel)
        {
            UserAccount userAccount = GetDomainEntity(viewModel);
            dbContext.UserAccountSet.Add(userAccount);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, UserAccountViewModel viewModel)
        {
            DbSet<UserAccount> entitySet = dbContext.UserAccountSet;

            UserAccount userAccount = GetDomainEntity(viewModel);

            entitySet.Attach(userAccount);

            dbContext.Entry(userAccount).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }
    }
}
