using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    public class CountryRepository : GenericRepository<Country>, ICategoryRepository 
    {
        public Country FindById(Guid categoryId)
        {
            return GetAll().FirstOrDefault(x => x.CategoryId == categoryId);
        }

    }
}
