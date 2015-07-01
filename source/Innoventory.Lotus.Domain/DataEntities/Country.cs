using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class Country
    {
        [Key]
        public Guid CountryID { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }

        [StringLength(5)]
        public string CountryCode { get; set; }

        [StringLength(5)]
        public string ISDCode { get; set; }


        public Guid CurrencyID { get; set; }


        public virtual List<Address> Addresses { get; set; }



    }
}
