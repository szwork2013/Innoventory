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
    [Export(typeof(IOrganisationSetupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrganisationSetupRepository : GenericRepository<OrganisationSetup>, IOrganisationSetupRepository
    {
        public OrganisationSetup FindById(Guid organisationSetupId)
        {
            return GetAll().FirstOrDefault(x => x.OrganisationSetupId == organisationSetupId);
        }
    }
}
