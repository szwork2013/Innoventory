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
