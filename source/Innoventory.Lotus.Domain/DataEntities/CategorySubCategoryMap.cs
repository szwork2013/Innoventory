﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class CategorySubCategoryMap
    {
        [Key]
        public Guid CategorySubCategoryMapId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SubCategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual List<Category> Categories { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
