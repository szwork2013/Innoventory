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
        [DataMember(Name= "customerId")]

        public Guid CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [DataMember(Name = "customerName")]

        public string CustomerName { get; set; }

        [DisplayName("Customer Contact No")]
        [DataMember(Name = "customerContactNo")]

        public string CustomerContactNo { get; set; }

        [DisplayName("Customer Email ID")]
        [DataMember(Name = "customerEmailId")]

        public string CustomerEmailId { get; set; }

                              
        [ScaffoldColumn(false)]
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
