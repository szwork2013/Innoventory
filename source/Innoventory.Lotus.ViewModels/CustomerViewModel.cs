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
    public class CustomerViewModel : IIdentifiable 
    {
        [ScaffoldColumn(false)]
        [DataMember]

        public Guid CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [DataMember]

        public string CustomerName { get; set; }

        [DisplayName("Customer Contact No")]
        [DataMember]

        public string CustomerContactNo { get; set; }

        [DisplayName("Customer Email ID")]
        [DataMember]

        public string CustomerEmailId { get; set; }

        public List<PurchaseOrderViewModel> PurchaseOrders { get; set; }


        public Guid EntityId
        {
            get
            {
                return CustomerId;
            }
            set
            {
                CustomerId = value;
            }
        }
    }
}
