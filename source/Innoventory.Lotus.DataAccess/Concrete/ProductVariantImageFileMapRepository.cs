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
    [Export(typeof(IProductVariantImageFileMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductVariantImageFileMapRepository : GenericRepository<ProductVariantImageFileMap>, IProductVariantImageFileMapRepository
    {
        public ProductVariantImageFileMap FindById(Guid productVariantId)
        {
            return GetAll().FirstOrDefault(x => x.ProductVariantId == productVariantId);
        }
    }
}
