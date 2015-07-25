using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    public class PurchaseReturnViewModel:IIdentifiable
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid PurchaseReturnId { get; set; }

        public DateTime PurchaseOrderDate { get; set; }
        public Guid SupplierId { get; set; }
        public decimal ShippingCost { get; set; }

        public  List<PurchaseOrderItemViewModel> PurchaseOrderItems { get; set; }

        public  SupplierViewModel Supplier { get; set; }

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
