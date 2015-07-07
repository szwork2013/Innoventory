using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class PurchaseReturnViewModel
    {
        [Key]
        public Guid PurchaseReturnId { get; set; }

        public DateTime PurchaseOrderDate { get; set; }
        public Guid SupplierId { get; set; }
        public decimal ShippingCost { get; set; }

        public  List<PurchaseOrderItemViewModel> PurchaseOrderItems { get; set; }

        public  SupplierViewModel Supplier { get; set; }
    }
}
