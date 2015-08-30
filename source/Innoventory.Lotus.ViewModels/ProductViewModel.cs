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
    public class ProductViewModel : IIdentifiable, IDisplayName
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


        [ScaffoldColumn(false)]
        [DataMember(Name = "categorySubCategoryMapId")]
        public Guid CategorySubCategoryMapId { get; set; }


        [DataMember(Name="categorySubCategoryMap")]
        public CategorySubCategoryMapViewModel CategorySubCategoryMap { get; set; }

        //[DisplayName("Category ID")]
        //[DataMember(Name = "categoryId")]
        //public Guid CategoryId { get; set; }

        //[DisplayName("Category Name")]
        //[DataMember(Name = "categoryName")]
        //public string CategoryName { get; set; }

        //[DisplayName("Sub Category ID")]
        //[DataMember(Name = "subCategoryId")]
        //public Guid SubCategoryId { get; set; }


        //[DisplayName("Sub Category Name")]
        //[DataMember(Name = "subCategoryName")]
        //public string SubCategoryName { get; set; }


        [DisplayName("Image ID")]
        [DataMember(Name = "imageId")]
        public Guid? ImageId { get; set; }

             
        [DataMember(Name = "volumeMeasureId")]
        public Guid VolueMeasureId { get; set; }
                
               
        [DataMember(Name = "volumeMeasureShortName")]
        public string volumeMeasureShortName { get; set; }


        [DataMember(Name = "productVariants")]
        public List<ProductVariantViewModel> ProductVariants { get; set; }

        [DataMember(Name = "productVariantListItems")]
        public List<ProductVariantListItem> ProductVariantListItems { get; set; }

        [DataMember(Name = "imageUrl")]
        public string ImageUrl { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return ProductId; }
            set { ProductId = value; }
        }


        [ScaffoldColumn(false)]
        public string DisplayName
        {
            get { return ProductName; }
        }
    }

    [DataContract]
    public class ProductListItem
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

        [DisplayName("Category Id")]
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

    }
}
