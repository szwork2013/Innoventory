using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{

    public class AddressViewModel
    {
         [ScaffoldColumn(false)]
        public Guid AddressID { get; set; }

        
        public Guid AddressMapId { get; set; }

        [DisplayName("Address Type")]
        public short AddressType { get; set; }

        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Post Code")]
        public string PostCode { get; set; }

        [DisplayName("State")]
        public string State { get; set; }


        public Guid CountryId { get; set; }

        [DisplayName("Default Address")]
        public bool DefaultAddress { get; set; }

        
        public CountryViewModel Country { get; set; }

    }
}
