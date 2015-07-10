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
