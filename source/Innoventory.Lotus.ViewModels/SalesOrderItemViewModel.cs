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
    [DataContract]
    public class SalesOrderItemViewModel : IIdentifiable
    {

        [Key]
        [ScaffoldColumn(false)]
        [DataMember(Name = "salesOrderItemId")]
        public Guid SalesOrderItemId { get; set; }

        [DataMember(Name = "salesOrderId")]
        public Guid SalesOrderId { get; set; }

        [DataMember(Name = "productVariantId")]
        public Guid ProductVariantId { get; set; }

        [DataMember(Name = "quantity")]
        public Decimal Quantity { get; set; }

        [DataMember(Name = "price")]
        public Decimal Price { get; set; }

        [DataMember(Name = "productVariant")]
        public virtual ProductVariantViewModel ProductVariant { get; set; }

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
