using Innoventory.Lotus.Business.Abstract;
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

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IUserRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRoleRepository : GenericRepository<UserRole, UserRoleViewModel>, IUserRoleRepository
    {

        protected UserRole GetDomainEntity(UserRoleViewModel viewModel)
        {
            UserRole userRole = ObjectMapper.PropertyMap(viewModel, new UserRole());

            return userRole;
        }



        protected override UserRoleViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<UserRole> entitySet = dbContext.UserRoleSet;

            UserRole dmUserRole = entitySet.FirstOrDefault(x => x.UserRoleId == id);

            UserRoleViewModel urVM = new UserRoleViewModel();

            UserRoleViewModel userRoleVM = ObjectMapper.PropertyMap(dmUserRole, urVM);

            return userRoleVM;

        }

        protected override List<UserRoleViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<UserRole> entitySet = dbContext.UserRoleSet;

            List<UserRole> userRoles = entitySet.ToList();

            List<UserRoleViewModel> retList = new List<UserRoleViewModel>();

            foreach (UserRole userRole in userRoles)
            {
                UserRoleViewModel urVM = new UserRoleViewModel();


                retList.Add(ObjectMapper.PropertyMap(userRole, urVM));

            }

            return retList;
        }

        protected override List<UserRoleViewModel> Find(InnoventoryDBContext dbContext, Func<UserRoleViewModel, bool> predicate)
        {

            List<UserRoleViewModel> userRoles = (GetEntities(dbContext)).Where(predicate).ToList();

            return userRoles;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<UserRole> entitySet = dbContext.UserRoleSet;

            //UserRoleViewModel userRoleVM = GetEntity(dbContext, id);


            UserRole userRole = entitySet.FirstOrDefault(x => x.UserRoleId == id);

            if (userRole != null)
            {
                entitySet.Remove(userRole);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, UserRoleViewModel viewModel)
        {
            UserRole userRole = GetDomainEntity(viewModel);
            dbContext.UserRoleSet.Add(userRole);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, UserRoleViewModel viewModel)
        {
            DbSet<UserRole> entitySet = dbContext.UserRoleSet;

            UserRole userRole = GetDomainEntity(viewModel);

            entitySet.Attach(userRole);

            dbContext.Entry(userRole).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }
    }
}
