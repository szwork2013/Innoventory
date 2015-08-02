using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Innoventory.Lotus.Core.Contracts;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{
    public class PurchaseOrderItemViewModel : IIdentifiable
    {
        [Key]
        [ScaffoldColumn(false)]
        [DataMember(Name = "purchaseOrderItemId")]
        public Guid PurchaseOrderItemId { get; set; }

        [DataMember(Name="purchaseOrderId")]
        public Guid PurchaseOrderId { get; set; }

        [DataMember(Name = "productVariantId")]
        public Guid ProductVariantId { get; set; }

        [DataMember(Name = "quantity")]
        public Decimal Quantity { get; set; }
               

        [DataMember(Name = "price")]
        public Decimal Price { get; set; }


        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
