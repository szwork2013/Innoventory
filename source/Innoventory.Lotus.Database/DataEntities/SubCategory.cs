using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.Database.DataEntities
{

    public class SubCategory
    {

        [Key]
        public Guid SubCategoryId{ get; set; }

        [Required]
        [StringLength(50)]
        public string SubCategoryName { get; set; }

        [Required]
        [StringLength(500)]
        public String Description { get; set; }
    }
}
