using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class SalesOrder
    {
        [Key]
        public Guid SalesOrderId { get; set; }
        public DateTime SaleOrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Taxes { get; set; }

        public virtual List<SalesOrderItem> SaleOrderItems { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
