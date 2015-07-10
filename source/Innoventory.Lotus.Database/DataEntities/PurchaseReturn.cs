using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class PurchaseReturn
    {
        [Key]
        public Guid PurchaseReturnId { get; set; }

        public DateTime PurchaseOrderDate { get; set; }
        public Guid SupplierId { get; set; }
        public decimal ShippingCost { get; set; }

        public virtual List<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}
