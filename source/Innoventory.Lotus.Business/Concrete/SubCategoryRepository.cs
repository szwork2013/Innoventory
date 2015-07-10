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
    [Export(typeof(ISubCategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategory FindById(Guid subCategoryId)
        {
            return GetAll().FirstOrDefault(x => x.SubCategoryId == subCategoryId);
        }

    }
}
