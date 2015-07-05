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
    [Export(typeof(IVolumeMeasureMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VolumeMeasureMapRepository : GenericRepository<VolumeMeasureMap>, IVolumeMeasureMapRepository
    {
        public VolumeMeasureMap FindById(Guid volumeMeasureMapId)
        {
            return GetAll().FirstOrDefault(x => x.VolumeMeasureMapId == volumeMeasureMapId);
        }
    }
}
