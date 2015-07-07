﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class CategorySubCategoryAttributeMapViewModel
    {

        public Guid CategorySubCategoryAttributeMapId { get; set; }
        public Guid CategorySubCategoryMapId { get; set; }
        public Guid ProductAttributeId { get; set; }

      
        public CategorySubCategoryMapViewModel CategorySubCategoryMap { get; set; }


        public ProductAttributeViewModel ProductAttribute { get; set; }

    }
}