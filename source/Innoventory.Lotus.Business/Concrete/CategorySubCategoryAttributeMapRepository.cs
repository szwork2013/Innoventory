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
    [Export(typeof(ICategorySubCategoryAttributeMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategorySubCategoryAttributeMapRepository : GenericRepository<CategorySubCategoryAttributeMap, CategorySubCategoryAttributeMapViewModel>, 
                                                                ICategorySubCategoryAttributeMapRepository
    {

       
       
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

              

        protected override List<CategorySubCategoryAttributeMapViewModel> Find(InnoventoryDBContext dbContext, Func<CategorySubCategoryAttributeMapViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, CategorySubCategoryAttributeMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CategorySubCategoryAttributeMapViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override CategorySubCategoryAttributeMapViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<CategorySubCategoryAttributeMapViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}
