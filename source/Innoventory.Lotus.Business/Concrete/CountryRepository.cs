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
    [Export(typeof(ICountryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public Country FindById(Guid countryId)
        {
            return GetAll().FirstOrDefault(x => x.CountryID == countryId);
        }
    }
}
