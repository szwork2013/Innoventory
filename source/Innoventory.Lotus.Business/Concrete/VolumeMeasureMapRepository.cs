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
    [Export(typeof(IVolumeMeasureMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VolumeMeasureMapRepository : GenericRepository<VolumeMeasureMap, VolumeMeasureMapViewModel>, IVolumeMeasureMapRepository
    {
        
        protected override VolumeMeasureMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<VolumeMeasureMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

     
        protected override bool AddEntity(InnoventoryDBContext dbContext, VolumeMeasureMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, VolumeMeasureMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<VolumeMeasureMapViewModel> Find(InnoventoryDBContext dbContext, Func<VolumeMeasureMapViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
