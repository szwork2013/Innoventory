using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class Currency
    {
        [Key]
        public Guid CurrencyID { get; set; }

        [StringLength(5)]
        public string CurrencyCode { get; set; }
        
        [StringLength(3)]
        public string CurrencySymbol { get; set; }
        
        [StringLength(50)]
        public string CurrencyFullName { get; set; }

      


    }
}
