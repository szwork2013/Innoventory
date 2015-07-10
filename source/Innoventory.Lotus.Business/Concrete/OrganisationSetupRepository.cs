using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
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
    public class OrganisationSetupRepository : GenericRepository<OrganisationSetup>, IOrganisationSetupRepository
    {
        public OrganisationSetup FindById(Guid organisationSetupId)
        {
            return GetAll().FirstOrDefault(x => x.OrganisationSetupId == organisationSetupId);
        }
    }
}
