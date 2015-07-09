using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerContactNo { get; set; }

        [StringLength(200)]
        public string CustomerEmailId { get; set; }

        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }

    }
}
