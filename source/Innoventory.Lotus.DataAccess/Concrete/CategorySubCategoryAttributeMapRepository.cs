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
    [Export(typeof(ICategorySubCategoryAttributeMapRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CategorySubCategoryAttributeMapRepository : GenericRepository<CategorySubCategoryAttributeMap>, ICategorySubCategoryAttributeMapRepository
    {
        public CategorySubCategoryAttributeMap FindById(Guid categorySubCategoryAttributeMapId)
        {
            return GetAll().FirstOrDefault(x => x.CategorySubCategoryAttributeMapId == categorySubCategoryAttributeMapId);
        }
    }
}