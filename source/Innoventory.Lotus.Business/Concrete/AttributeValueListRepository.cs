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
    [Export(typeof(IAttributeValueListRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AttributeValueListRepository : GenericRepository<AttributeValueList, AttributeValueListViewModel>, IAttributeValueListRepository
    {

        protected override AttributeValueListViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<AttributeValueList> entitySet = dbContext.AttributeValueListSet;

            AttributeValueList attributeValueListItem = entitySet.Where(x => x.AttributeValueListId == id).FirstOrDefault();

            if (attributeValueListItem != null)
            {

                AttributeValueListViewModel ret = ObjectMapper.PropertyMap(attributeValueListItem, new AttributeValueListViewModel());
                return ret;
            }

            return null;

        }

        protected override List<AttributeValueListViewModel> GetEntities(InnoventoryDBContext dbContext)
        {

            DbSet<AttributeValueList> entitySet = dbContext.AttributeValueListSet;

            List<AttributeValueList> entities = dbContext.AttributeValueListSet.ToList();

            List<AttributeValueListViewModel> result = new List<AttributeValueListViewModel>();

            entities.ForEach(x => result.Add(ObjectMapper.PropertyMap(x, new AttributeValueListViewModel())));

            return result;

        }

      
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<AttributeValueList> entitySet = dbContext.AttributeValueListSet;

            var entity = entitySet.Where(x => x.AttributeValueListId == id).FirstOrDefault();

            if(entity != null)
            {
                entitySet.Remove(entity);
                dbContext.SaveChanges();
            }

            return true;
        }

      
        protected override bool AddEntity(InnoventoryDBContext dbContext, AttributeValueListViewModel viewModel)
        {
            AttributeValueList entity = ObjectMapper.PropertyMap(viewModel, new AttributeValueList());

            dbContext.AttributeValueListSet.Add(entity);
            dbContext.SaveChanges();

            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, AttributeValueListViewModel viewModel)
        {
            DbSet<AttributeValueList> entitySet = dbContext.AttributeValueListSet;

            AttributeValueList entity = ObjectMapper.PropertyMap(viewModel, new AttributeValueList());

            entitySet.Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();

            return true;
           
        }

      

        protected override List<AttributeValueListViewModel> Find(InnoventoryDBContext dbContext, Func<AttributeValueListViewModel, bool> predicate)
        {
            List<AttributeValueListViewModel> result = GetEntities(dbContext).Where(predicate).ToList();
            return result;
        }
    }
}
