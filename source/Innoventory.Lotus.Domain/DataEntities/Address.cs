using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class Address
    {
        [Key]
        public Guid AddressID { get; set; }

        public Guid AddressMapId { get; set; }
        public short AddressType { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string PostCode { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [StringLength(100)]
        public Guid CountryID { get; set; }

        public bool DefaultAddress { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

    }
}
