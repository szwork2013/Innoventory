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

        public Guid CategoryId { get; set; }

        public Guid SubCategoryAttributeMapID { get; set; }

        [StringLength(50)]
        public string AttributeValue { get; set; }


        [ForeignKey("SubCategoryAttributeMapID")]
        public virtual SubCategoryAttributeMap SubCategoryAttributeMap { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
                
    }
}
