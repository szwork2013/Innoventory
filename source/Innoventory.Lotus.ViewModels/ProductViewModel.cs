using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Innoventory.Lotus.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid ProductId { get; set; }

        [ScaffoldColumn(false)]
        public int ItemType { get; set; }

        
        public string ProductName { get; set; }
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

    }
}
