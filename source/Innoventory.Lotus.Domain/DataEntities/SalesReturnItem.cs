using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class SalesReturnItem
    {

        [Key]
        public Guid SalesReturnItemId { get; set; }
        public Guid SalesReturnId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Decimal Quantity { get; set; }
        public Guid Unit { get; set; }
        public Decimal Price { get; set; }

        [ForeignKey("SalesReturnId")]
        public virtual SalesReturn SalesReturn { get; set; }

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
