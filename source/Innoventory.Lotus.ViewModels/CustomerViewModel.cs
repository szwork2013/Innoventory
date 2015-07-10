using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    public class CustomerViewModel : IIdentifiable 
    {

        public Guid CustomerId { get; set; }


        public string CustomerName { get; set; }


        public string CustomerContactNo { get; set; }


        public string CustomerEmailId { get; set; }

        public List<PurchaseOrderViewModel> PurchaseOrders { get; set; }


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
