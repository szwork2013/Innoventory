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
    [Export(typeof(IOrganisationSetupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrganisationSetupRepository : GenericRepository<OrganisationSetup, OrganisationSetupViewModel>, IOrganisationSetupRepository
    {
       
        protected override OrganisationSetupViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<OrganisationSetupViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

       
        protected override bool AddEntity(InnoventoryDBContext dbContext, OrganisationSetupViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, OrganisationSetupViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<OrganisationSetupViewModel> Find(InnoventoryDBContext dbContext, Func<OrganisationSetupViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
