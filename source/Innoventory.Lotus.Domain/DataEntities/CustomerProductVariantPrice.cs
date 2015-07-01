using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class CustomerProductVariantPrice
    {
        [Key]
        public Guid CustomerProductVariantPriceId { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ProductVariantId { get; set; }
        public int PricingType { get; set; }
        public decimal PricingValue { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }


        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

    }
}
