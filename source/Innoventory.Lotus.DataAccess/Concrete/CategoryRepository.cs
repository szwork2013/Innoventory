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
    [Export(typeof(ICategoryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
    {
        public Category FindById(Guid categoryId)
        {
            return GetAll().FirstOrDefault(x => x.CategoryId == categoryId);
        }

    }
}