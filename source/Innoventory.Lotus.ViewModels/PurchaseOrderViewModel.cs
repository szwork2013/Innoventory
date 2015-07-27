using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class PurchaseOrderViewModel : IIdentifiable
    {

        [Key]
        [ScaffoldColumn(false)]
        [DataMember(Name = "purchaseOrderId")]
        public Guid PurchaseOrderId { get; set; }

        [DisplayName("Purchase Order Date")]
        [DataMember(Name = "purchaseOrderDate")]
        public DateTime PurchaseOrderDate { get; set; }

        [DisplayName("Supplier ID")]
        [DataMember(Name = "supplierId")]
        public Guid SupplierId { get; set; }

        [DisplayName("Shipping Cost")]
        [DataMember(Name = "shippingCost")]
        public decimal ShippingCost { get; set; }

        [DisplayName("Taxes")]
        [DataMember(Name = "taxes")]
        public decimal Taxes { get; set; }

        [DataMember(Name="purchaseOrderItems")]
        public List<PurchaseOrderItemViewModel> PurchaseOrderItems { get; set; }

        [DataMember(Name="supplier")]
        public SupplierViewModel Supplier { get; set; }


        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return PurchaseOrderId; }

            set { PurchaseOrderId = value; }
        }
    }
}
