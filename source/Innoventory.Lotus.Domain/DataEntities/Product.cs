using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        public int ItemType { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }

        public Guid SubCategoryId { get; set; }

        public decimal? ReorderPoint { get; set; }

        public decimal? ReorderQuantity { get; set; }

        public Guid UnitId { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public Guid? ImageId { get; set; }

        public Guid SalesOrderUnitId { get; set; }

        public Guid PurchaseOrderUnitId { get; set; }

        public Guid CategorySubCategoryMapId { get; set; }

        public virtual IList<ProductVariant> ProductVariants { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }

    }
}
