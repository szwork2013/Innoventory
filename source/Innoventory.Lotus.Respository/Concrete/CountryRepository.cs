using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Repository.Concrete
{
    [Export(typeof(ICountryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CountryRepository : GenericRepository<Country, CountryViewModel>, ICountryRepository
    {

        protected Country GetDomainEntity(CountryViewModel viewModel)
        {
            Country country = ObjectMapper.PropertyMap(viewModel, new Country());

            return country;
        }



        protected override CountryViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Country> entitySet = dbContext.CountrySet;

            Country dmCountry = entitySet.FirstOrDefault(x => x.CountryID == id);

            CountryViewModel counVM = new CountryViewModel();

            CountryViewModel countryVM = ObjectMapper.PropertyMap(dmCountry, counVM);

            return countryVM;

        }

        protected override List<CountryViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Country> entitySet = dbContext.CountrySet;

            List<Country> countries = entitySet.ToList();

            List<CountryViewModel> retList = new List<CountryViewModel>();

            foreach (Country country in countries)
            {
                CountryViewModel counVM = new CountryViewModel();


                retList.Add(ObjectMapper.PropertyMap(country, counVM));

            }

            return retList;
        }

        protected override List<CountryViewModel> Find(InnoventoryDBContext dbContext, Func<CountryViewModel, bool> predicate)
        {

            List<CountryViewModel> countries = (GetEntities(dbContext)).Where(predicate).ToList();

            return countries;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Country> entitySet = dbContext.CountrySet;

            //CountryViewModel countryVM = GetEntity(dbContext, id);


            Country country = entitySet.FirstOrDefault(x => x.CountryID == id);

            if (country != null)
            {
                entitySet.Remove(country);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, CountryViewModel viewModel)
        {
            Country country = GetDomainEntity(viewModel);
            dbContext.CountrySet.Add(country);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CountryViewModel viewModel)
        {
            DbSet<Country> entitySet = dbContext.CountrySet;

            Country country = GetDomainEntity(viewModel);

            entitySet.Attach(country);

            dbContext.Entry(country).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }


    }
}
