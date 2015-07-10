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
    [Export(typeof(ICategorySubCategoryMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategorySubCategoryMapRepository : GenericRepository<CategorySubCategoryMap, CategorySubCategoryMapViewModel>, 
                                                    ICategorySubCategoryMapRepository
    {

        protected override CategorySubCategoryMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<CategorySubCategoryMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

        

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        

        protected override bool AddEntity(InnoventoryDBContext dbContext, CategorySubCategoryMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CategorySubCategoryMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<CategorySubCategoryMapViewModel> Find(InnoventoryDBContext dbContext, Func<CategorySubCategoryMapViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
