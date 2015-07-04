using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class ProductVariantAttributeValue
    {

        [Key]
        [Column(Order = 1)]
        public Guid ProductVariantAttributeValueId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid AttributeValueListId { get; set; }

        [ForeignKey("AttributeValueListId")]
        public virtual AttributeValueList AttributeValueList { get; set; }


        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }


    }
}
