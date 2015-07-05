﻿using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.DataAccess.Concrete
{
    [Export(typeof(ICurrencyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public Currency FindById(Guid currencyId)
        {
            return GetAll().FirstOrDefault(x => x.CurrencyID == currencyId);
        }
    }
}
