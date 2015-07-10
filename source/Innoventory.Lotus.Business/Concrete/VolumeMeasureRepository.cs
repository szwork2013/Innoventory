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
    [Export(typeof(IVolumeMeasureRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VolumeMeasureRepository : GenericRepository<VolumeMeasure, VolumeMeasureViewModel>, IVolumeMeasureRepository
    {
      
        protected override VolumeMeasureViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<VolumeMeasureViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

    

        protected override bool AddEntity(InnoventoryDBContext dbContext, VolumeMeasureViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, VolumeMeasureViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<VolumeMeasureViewModel> Find(InnoventoryDBContext dbContext, Func<VolumeMeasureViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
