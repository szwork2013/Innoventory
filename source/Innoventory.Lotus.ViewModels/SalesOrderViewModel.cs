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
    public class SalesOrderViewModel:IIdentifiable
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid SalesOrderId { get; set; }
        public DateTime SaleOrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Taxes { get; set; }

        public List<SalesOrderItemViewModel> SaleOrderItems { get; set; }

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
