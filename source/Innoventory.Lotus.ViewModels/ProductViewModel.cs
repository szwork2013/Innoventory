using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class ProductViewModel : IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember(Name = "productId")]
        public Guid ProductId { get; set; }

        [DisplayName("Item Type")]
        [DataMember(Name = "itemType")]
        public int ItemType { get; set; }

        [DisplayName("Item Type Value")]
        [DataMember(Name = "itemTypeValue")]
        public string ItemTypeValue { get; set; }

        [DisplayName("Product Name")]
        [DataMember(Name = "productName")]
        public string ProductName { get; set; }

        [DisplayName("Description")]
        [DataMember(Name = "description")]
        public string Description { get; set; }


        [DataMember(Name = "remarks")]
        public string Remarks { get; set; }

        [DisplayName("Category ID")]
        [DataMember(Name = "categoryId")]
        public Guid CategoryId { get; set; }

        [DisplayName("Category Name")]
        [DataMember(Name = "categoryName")]
        public string CategoryName { get; set; }

        [DisplayName("Sub Category ID")]
        [DataMember(Name = "subCategoryId")]
        public Guid SubCategoryId { get; set; }


        [DisplayName("Sub Category Name")]
        [DataMember(Name = "subCategoryName")]
        public string SubCategoryName { get; set; }


        [DisplayName("Image ID")]
        [DataMember(Name = "imageId")]
        public Guid? ImageId { get; set; }

        [DisplayName("Sales Order Unit ID")]
        [DataMember(Name = "salesOrderUnitId")]
        public Guid SalesOrderVolumeMeasureId { get; set; }

        [DisplayName("Sales Order Volume Measure")]
        [DataMember(Name = "salesOrderVolumeMeasureName")]
        public string SalesOrderVolumeMeasureName { get; set; }

        [DisplayName("Purchase Order Volume Measure Id")]
        [DataMember(Name = "purchaseOrderVolumeMeasureId")]
        public Guid PurchaseOrderVolueMeasureId { get; set; }

        [DisplayName("Purschase Order Unit")]
        [DataMember(Name = "purchaseOrderUnit")]
        public Guid PurchaseVolumeMeasureName { get; set; }

        [DataMember(Name = "productVariants")]
        public List<ProductVariantViewModel> ProductVariants { get; set; }

        [DataMember(Name = "imageUrl")]
        public string ImageUrl { get; set; }

        public Guid EntityId
        {
            get
            {
                return ProductId;
            }
            set
            {
                ProductId = value;
            }
        }


    }
}
