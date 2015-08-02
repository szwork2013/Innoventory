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
    public class SupplierViewModel : IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember(Name = "supplierId")]
        public Guid SupplierId { get; set; }

        [DataMember(Name = "supplierName")]
        public string SupplierName { get; set; }

        [DataMember(Name = "supplierContactNo")]
        public string SupplierContactNo { get; set; }

        [DataMember(Name = "supplierEmailId")]
        public string SupplierEmailId { get; set; }


        [DataMember(Name = "currency")]
        public CurrencyViewModel Currency { get; set; }


        [DataMember(Name = "supplierAddresses")]
        public List<AddressViewModel> SupplierAddresses { get; set; }

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
