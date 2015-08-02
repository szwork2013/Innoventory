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
    public class CurrencyViewModel : IIdentifiable
    {

        [ScaffoldColumn(false)]
        [DataMember(Name = "currencyId")]
        public Guid CurrencyID { get; set; }


        [DisplayName("Currency Code")]
        [DataMember(Name = "currencyCode")]
        public string CurrencyCode { get; set; }

        [DisplayName("Currency Symbol")]
        [DataMember(Name = "currencySymbol")]
        public string CurrencySymbol { get; set; }

        [DisplayName("Currency Full Name")]
        [DataMember(Name = "currencyFullName")]
        public string CurrencyFullName { get; set; }


        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return CurrencyID; }

            set { CurrencyID = value; }
        }
    }
}
