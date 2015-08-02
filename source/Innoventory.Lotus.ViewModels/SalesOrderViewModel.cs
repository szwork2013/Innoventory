using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class SalesOrderViewModel : IIdentifiable
    {
        [Key]
        [ScaffoldColumn(false)]
        [DataMember(Name = "salesOrderId")]
        public Guid SalesOrderId { get; set; }

        [DataMember(Name = "salesOrderDate")]
        public DateTime SaleOrderDate { get; set; }

        [DataMember(Name = "customerId")]
        public Guid CustomerId { get; set; }

        [DataMember(Name = "shippingCost")]
        public decimal ShippingCost { get; set; }

        [DataMember(Name = "taxes")]
        public decimal Taxes { get; set; }

        [DataMember(Name = "salesOrderItems")]
        public List<SalesOrderItemViewModel> SaleOrderItems { get; set; }

        [DataMember(Name = "customer")]
        public CustomerViewModel Customer { get; set; }

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
