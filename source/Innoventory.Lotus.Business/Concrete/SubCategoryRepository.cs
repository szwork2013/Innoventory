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
    [Export(typeof(ISubCategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubCategoryRepository : GenericRepository<SubCategory, SubCategoryViewModel>, ISubCategoryRepository
    {
       
        protected override SubCategoryViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        protected override List<SubCategoryViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            throw new NotImplementedException();
        }

       
        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        
        protected override bool AddEntity(InnoventoryDBContext dbContext, SubCategoryViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, SubCategoryViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        protected override List<SubCategoryViewModel> Find(InnoventoryDBContext dbContext, Func<SubCategoryViewModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
