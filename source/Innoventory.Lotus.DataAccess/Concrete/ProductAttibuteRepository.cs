﻿using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(IProductAttibuteRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductAttibuteRepository : GenericRepository<ProductAttribute>, IProductAttibuteRepository
    {
        public ProductAttribute FindById(Guid productAttributeId)
        {
            return GetAll().FirstOrDefault(x => x.ProductAttributeId == productAttributeId);
        }
    }
}
