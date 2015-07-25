using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IVolumeMeasureRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VolumeMeasureRepository : GenericRepository<VolumeMeasure, VolumeMeasureViewModel>, IVolumeMeasureRepository
    {

        protected VolumeMeasure GetDomainEntity(VolumeMeasureViewModel viewModel)
        {
            VolumeMeasure volumemeasure = ObjectMapper.PropertyMap(viewModel, new VolumeMeasure());

            return volumemeasure;
        }

        protected override VolumeMeasureViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<VolumeMeasure> entitySet = dbContext.VolumeMeasureSet;

            VolumeMeasure dmVolumeMeasure = entitySet.FirstOrDefault(x => x.VolumeMeasureId == id);

            VolumeMeasureViewModel vmVM = new VolumeMeasureViewModel();

            VolumeMeasureViewModel volumemeasureVM = ObjectMapper.PropertyMap(dmVolumeMeasure, vmVM);

            return volumemeasureVM;

        }

        protected override List<VolumeMeasureViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<VolumeMeasure> entitySet = dbContext.VolumeMeasureSet;

            List<VolumeMeasure> volumeMeasures = entitySet.ToList();

            List<VolumeMeasureViewModel> retList = new List<VolumeMeasureViewModel>();

            foreach (VolumeMeasure vm in volumeMeasures)
            {
                VolumeMeasureViewModel volumeMeasure = new VolumeMeasureViewModel();


                retList.Add(ObjectMapper.PropertyMap(vm, volumeMeasure));

            }

            return retList;
        }

        

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<VolumeMeasure> entitySet = dbContext.VolumeMeasureSet;

            //VolumeMeasureViewModel VolumeMeasureVM = GetEntity(dbContext, id);


            VolumeMeasure VolumeMeasure = entitySet.FirstOrDefault(x => x.VolumeMeasureId == id);

            if (VolumeMeasure != null)
            {
                entitySet.Remove(VolumeMeasure);
                dbContext.SaveChanges();
            }
            return true;
        }

    

        protected override bool AddEntity(InnoventoryDBContext dbContext, VolumeMeasureViewModel viewModel)
        {
            VolumeMeasure volumemeasure = GetDomainEntity(viewModel);
            dbContext.VolumeMeasureSet.Add(volumemeasure);

            dbContext.SaveChanges();
            return true;


        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, VolumeMeasureViewModel viewModel)
        {
            DbSet<VolumeMeasure> entitySet = dbContext.VolumeMeasureSet;

            VolumeMeasure volumemeasure = GetDomainEntity(viewModel);

            entitySet.Attach(volumemeasure);

            dbContext.Entry(volumemeasure).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;
        }

        protected override List<VolumeMeasureViewModel> Find(InnoventoryDBContext dbContext, Func<VolumeMeasureViewModel, bool> predicate)
        {
            List<VolumeMeasureViewModel> volumemeasures = (GetEntities(dbContext)).Where(predicate).ToList();

            return volumemeasures;
        }
    }
}
