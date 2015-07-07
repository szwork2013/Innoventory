using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class SalesOrderViewModel
    {
        [Key]
        public Guid SalesOrderId { get; set; }
        public DateTime SaleOrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Taxes { get; set; }

        public List<SalesOrderItemViewModel> SaleOrderItems { get; set; }

        public CustomerViewModel Customer { get; set; }
    }
}
