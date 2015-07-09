using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class ProductAttribute
    {
        [Key]
        public Guid ProductAttributeId { get; set; }

        [StringLength(100)]
        public string AttributeName { get; set; }

        [StringLength(200)]
        public string AttributeDescription { get; set; }

    }
}
