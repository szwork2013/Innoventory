using Innoventory.Lotus.Repository.Abstract;
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

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ISubCategoryAttributeMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubCategoryAttributeMapRepository : GenericRepository<SubCategoryAttributeMap, SubCategoryAttributeMapViewModel>,
                                                                ISubCategoryAttributeMapRepository
    {


        protected override List<SubCategoryAttributeMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<SubCategoryAttributeMap> subCategoryAttributeMapSet = dbContext.SubCategoryAttributeMapSet;

            List<SubCategoryAttributeMapViewModel> entities = new List<SubCategoryAttributeMapViewModel>();

            subCategoryAttributeMapSet.ToList().ForEach(x => entities.Add(ObjectMapper.PropertyMap(x, new SubCategoryAttributeMapViewModel())));

            return entities;
        }

        protected override List<SubCategoryAttributeMapViewModel> Find(InnoventoryDBContext dbContext, Func<SubCategoryAttributeMapViewModel, bool> predicate)
        {
            List<SubCategoryAttributeMapViewModel> entities = GetEntities(dbContext).Where(predicate).ToList();
            return entities;

        }

        protected override SubCategoryAttributeMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<SubCategoryAttributeMap> entitySet = dbContext.SubCategoryAttributeMapSet;

            SubCategoryAttributeMap retEntity = entitySet.FirstOrDefault(x => x.SubCategoryAttributeMapId == id);

            return ObjectMapper.PropertyMap(retEntity, new SubCategoryAttributeMapViewModel());
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, SubCategoryAttributeMapViewModel viewModel)
        {
            DbSet<SubCategoryAttributeMap> entitySet = dbContext.SubCategoryAttributeMapSet;

            SubCategoryAttributeMap entity = ObjectMapper.PropertyMap(viewModel, new SubCategoryAttributeMap());

            entitySet.Add(entity);

            dbContext.SaveChanges();

            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SubCategoryAttributeMapViewModel viewModel)
        {
            DbSet<SubCategoryAttributeMap> entitySet = dbContext.SubCategoryAttributeMapSet;

            SubCategoryAttributeMap entity = ObjectMapper.PropertyMap(viewModel, new SubCategoryAttributeMap());

            entitySet.Attach(entity);
            
            dbContext.Entry(entity).State = EntityState.Modified;
            
            dbContext.SaveChanges();

            return true;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<SubCategoryAttributeMap> entitySet = dbContext.SubCategoryAttributeMapSet;

            SubCategoryAttributeMap entity = entitySet.FirstOrDefault(x => x.SubCategoryAttributeMapId == id);

            if(entity != null)
            {
                entitySet.Remove(entity);
                dbContext.SaveChanges();
            }

            return true;

        }









    }
}
