using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class CountryViewModel:IIdentifiable 
    {

        public Guid CountryID { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        public string CountryCode { get; set; }


        public string ISDCode { get; set; }


        public Guid CurrencyID { get; set; }


        public List<AddressViewModel> Addresses { get; set; }






        public Guid EntityId
        {
            get
            {
                return CountryID;
            }
            set
            {
                CountryID = value;
            }
        }
    }
}
