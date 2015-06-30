using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class CategorySubCategoryAttributeMap
    {
        [Key]
        public Guid CategorySubCategoryAttributeMapID { get; set; }
        public Guid CategorySubCategoryMapId { get; set; }
        public Guid ProductAttributeId { get; set; }

        [ForeignKey("CategorySubCategoryMapId")]
        public CategorySubCategoryMap CategorySubCategoryMap { get; set; }


        [ForeignKey("ProductAttributeId")]
        public virtual ProductAttribute ProductAttribute { get; set; }

    }
}
