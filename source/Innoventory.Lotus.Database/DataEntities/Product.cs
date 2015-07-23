using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        public int ItemType { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Remarks { get; set; }
        
        public Guid SalesVolumeMeasureId { get; set; }

        public Guid PurchaseVolumeMeasureId { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public Guid? ImageId { get; set; }
               

        public Guid CategorySubCategoryMapId { get; set; }

        public virtual IList<ProductVariant> ProductVariants { get; set; }
                     

    }
}
