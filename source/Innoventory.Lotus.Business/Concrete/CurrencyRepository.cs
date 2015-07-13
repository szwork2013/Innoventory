using Innoventory.Lotus.Business.Abstract;
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

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(ICurrencyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrencyRepository : GenericRepository<Currency, CurrencyViewModel>, ICurrencyRepository
    {

        protected Currency GetDomainEntity(CurrencyViewModel viewModel)
        {
            Currency currency = ObjectMapper.PropertyMap(viewModel, new Currency());

            return currency;
        }

        protected override CurrencyViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Currency> entitySet = dbContext.CurrencySet;

            Currency dmCurrency = entitySet.FirstOrDefault(x => x.CurrencyID == id);

            CurrencyViewModel currVM = new CurrencyViewModel();

            CurrencyViewModel currencyVM = ObjectMapper.PropertyMap(dmCurrency, currVM);

            return currencyVM;

        }

        protected override List<CurrencyViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Currency> entitySet = dbContext.CurrencySet;

            List<Currency> currencies = entitySet.ToList();

            List<CurrencyViewModel> retList = new List<CurrencyViewModel>();

            foreach (Currency currency in currencies)
            {
                CurrencyViewModel currVM = new CurrencyViewModel();


                retList.Add(ObjectMapper.PropertyMap(currency, currVM));

            }

            return retList;
        }

        protected override List<CurrencyViewModel> Find(InnoventoryDBContext dbContext, Func<CurrencyViewModel, bool> predicate)
        {

            List<CurrencyViewModel> currencies = (GetEntities(dbContext)).Where(predicate).ToList();

            return currencies;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Currency> entitySet = dbContext.CurrencySet;

            //CurrencyViewModel currencyVM = GetEntity(dbContext, id);


            Currency currency = entitySet.FirstOrDefault(x => x.CurrencyID == id);

            if (currency != null)
            {
                entitySet.Remove(currency);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, CurrencyViewModel viewModel)
        {
            Currency currency = GetDomainEntity(viewModel);
            dbContext.CurrencySet.Add(currency);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CurrencyViewModel viewModel)
        {
            DbSet<Currency> entitySet = dbContext.CurrencySet;

            Currency currency = GetDomainEntity(viewModel);

            entitySet.Attach(currency);

            dbContext.Entry(currency).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }
    }
}
