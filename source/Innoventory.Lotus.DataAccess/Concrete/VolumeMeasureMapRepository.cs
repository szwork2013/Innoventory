﻿using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
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
