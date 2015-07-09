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
    [Export(typeof(ICategorySubCategoryMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategorySubCategoryMapRepository : GenericRepository<CategorySubCategoryMap>, ICategorySubCategoryMapRepository
    {
        public CategorySubCategoryMap FindById(Guid categorySubCategoryMapId)
        {
            return GetAll().FirstOrDefault(x => x.CategorySubCategoryMapId == categorySubCategoryMapId);
        }
    }
}
