using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Abstract
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        SubCategory FindById(Guid subCategoryId);
    }
}
