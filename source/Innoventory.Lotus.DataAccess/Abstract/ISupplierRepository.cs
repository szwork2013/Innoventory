﻿using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Abstract
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Supplier FindById(Guid supplierId);
    }
}
