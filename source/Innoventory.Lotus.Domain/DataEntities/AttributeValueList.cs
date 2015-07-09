using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class AttributeValueList
    {

        [Key]
        public Guid AttributeValueListId { get; set; }

        public Guid CategorySubCategoryAttributeMapID { get; set; }

        [StringLength(50)]
        public string AttributeValue { get; set; }


        [ForeignKey("CategorySubCategoryAttributeMapID")]
        public virtual CategorySubCategoryAttributeMap CategorySubCategoryAttributeMap { get; set; }

        public virtual List<ProductVariantAttributeValue> ProductVariantAttributeValue { get; set; }
    }
}
