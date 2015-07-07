using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.ViewModels
{
    public class SalesReturnItemViewModel
    {

        public Guid SalesReturnItemId { get; set; }
        public Guid SalesReturnId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Decimal Quantity { get; set; }
        public Guid Unit { get; set; }
        public Decimal Price { get; set; }

        public virtual SalesReturnViewModel SalesReturn { get; set; }

        public virtual ProductVariantViewModel ProductVariant { get; set; }
    }
}
