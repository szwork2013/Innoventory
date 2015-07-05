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
    [Export(typeof(IVolumeMeasureRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VolumeMeasureRepository : GenericRepository<VolumeMeasure>, IVolumeMeasureRepository
    {
        public VolumeMeasure FindById(Guid volumeMeasureId)
        {
            return GetAll().FirstOrDefault(x => x.VolumeMeasureId == volumeMeasureId);
        }
    }
}
