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
    public class CountryViewModel:IIdentifiable , IDisplayName
    {

        [ScaffoldColumn(false)]
        [DataMember]
        public Guid CountryID { get; set; }

        [DisplayName("Country Name")]
        [DataMember]
        public string CountryName { get; set; }

        [DisplayName("Country Code")]
        [DataMember]
        public string CountryCode { get; set; }

        [DisplayName("ISD Code")]
        [DataMember]
        public string ISDCode { get; set; }

        [DataMember]
        public Guid CurrencyID { get; set; }


        public List<AddressViewModel> Addresses { get; set; }
               

        public Guid EntityId
        {
            get{return CountryID; }
            set {CountryID = value;}
        }

        public string DisplayName
        {
            get { return string.Format("{0}({1})", CountryName, CountryCode); }
        }
    }
}
