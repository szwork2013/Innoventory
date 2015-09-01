using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; }
        [StringLength(100)]
        public string SupplierName { get; set; }
        [StringLength(50)]
        public string SupplierContactNo { get; set; }
        [StringLength(200)]
        public string SupplierEmailId { get; set; }

        public Guid CurrencyId { get; set; }

        //[ForeignKey("CurrencyId")]
        //public Currency Currency { get; set; }




    }
}
