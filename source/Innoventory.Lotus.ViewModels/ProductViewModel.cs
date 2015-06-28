using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Innoventory.Lotus.ViewModels
{

    [DataContract]
    public class ProductViewModel
    {
        [Key]

        [ScaffoldColumn(false)]
        [Browsable(false)]
        [DataMember(Name = "productId")]
        public Guid ProductId { get; set; }


        [DataMember(Name = "itemType")]
        public int ItemType { get; set; }

        [DataMember(Name = "productName")]
        public string ProductName { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "remarks")]
        public string Remarks { get; set; }

        [DataMember(Name="categoryId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public Guid CategoryId { get; set; }

        [DataMember(Name = "categoryName")]
        public string CategoryName { get; set; }

        [DataMember(Name = "subCategoryId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public Guid SubCategoryId { get; set; }

        [DataMember(Name = "subCategoryName")]
        public string SubCategoryName { get; set; }

        [DataMember(Name = "reorderPoint")]
        public decimal? ReorderPoint { get; set; }

        [DataMember(Name = "reorderQuantity")]
        public decimal? ReorderQuantity { get; set; }

        [DataMember(Name = "unitId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public Guid UnitId { get; set; }


        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [DataMember(Name = "imageId")]
        public Guid? ImageId { get; set; }

        [DataMember(Name = "saleOrderUnitId")]
        public Guid SalesOrderUnitId { get; set; }

        [DataMember(Name = "salesOrderUnit")]
        public string SalesOrderUnit { get; set; }

        [DataMember(Name = "purchaseUnitId")]
        public Guid PurchaseOrderUnitId { get; set; }
        
        [DataMember(Name = "purchaseUnitName")]
        public Guid PurchaseOrderUnitName { get; set; }


    }
}
