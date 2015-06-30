using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class PurchaseOrderItem
    {
        [Key]
        public Guid PurchaseReturnItemId { get; set; }
        public Guid PurchaseReturnId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Decimal Quantity { get; set; }
        public Guid Unit { get; set; }
        public Decimal Price { get; set; }

        [ForeignKey("PurchaseReturnId")]
        public virtual PurchaseReturn PurchaseReturn { get; set; }

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }


    }
}
