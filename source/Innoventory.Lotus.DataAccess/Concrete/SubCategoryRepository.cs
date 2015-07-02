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
    [Export(typeof(ISubCategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategory FindById(Guid subCategoryId)
        {
            return GetAll().FirstOrDefault(x => x.SubCategoryId == subCategoryId);
        }

    }
}
