using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.ViewModels
{
    public class SalesOrderItemViewModel
    {

        [Key]
        public Guid SalesOrderItemId { get; set; }
        public Guid SalesOrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Decimal Quantity { get; set; }
        public Guid Unit { get; set; }
        public Decimal Price { get; set; }

        public virtual SalesOrderViewModel SalesOrder { get; set; }

        public virtual ProductVariantViewModel ProductVariant { get; set; }
    }
}
