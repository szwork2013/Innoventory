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
    [Export(typeof(ISalesReturnRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SalesReturnRepository : GenericRepository<SalesReturn>, ISalesReturnRepository
    {
        public SalesReturn FindById(Guid salesReturnId)
        {
            return GetAll().FirstOrDefault(x => x.SalesReturnId == salesReturnId);
        }
    }
}