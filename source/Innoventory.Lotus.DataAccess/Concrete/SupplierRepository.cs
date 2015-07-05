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
    [Export(typeof(ISupplierRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public Supplier FindById(Guid supplierId)
        {
            return GetAll().FirstOrDefault(x => x.SupplierId == supplierId);
        }
    }
}