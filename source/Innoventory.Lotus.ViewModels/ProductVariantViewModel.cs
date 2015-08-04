using Innoventory.Lotus.Core.Contracts;
using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class ProductVariantViewModel : IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember(Name = "productVariantId")]
        public Guid ProductVariantId { get; set; }

        [DisplayName("Product ID")]
        [DataMember(Name = "productId")]
        public Guid ProductId { get; set; }

        [DisplayName("Bar Code")]
        [DataMember(Name = "barCode")]
        public string BarCode { get; set; }

        
        [DisplayName("Sales Volume")]
        [DataMember(Name = "salesVolume")]
        public decimal? SalesVolume { get; set; }

        [DisplayName("Purchase Volume")]
        [DataMember(Name = "purchaseVolume")]
                
        public decimal? PurchaseVolume { get; set; }

        [DataMember(Name = "reorderPoint")]
        public decimal? ReorderPoint { get; set; }

        [DataMember(Name = "reorderQuantity")]
        public decimal? ReorderQuantity { get; set; }

        [DisplayName("Case Length")]
        [DataMember(Name = "caseLength")]
        public decimal? CaseLength { get; set; }

        [DisplayName("Case Width")]
        [DataMember(Name = "caseWidth")]
        public decimal? CaseWidth { get; set; }

        [DisplayName("Case Height")]
        [DataMember(Name = "caseHeight")]
        public decimal? CaseHeight { get; set; }

        [DisplayName("Case Weight")]
        [DataMember(Name = "caseWeight")]
        public decimal? CaseWeight { get; set; }

        [DisplayName("Product Length")]
        [DataMember(Name = "productLength")]
        public decimal? ProductLength { get; set; }

        [DisplayName("Product Width")]
        [DataMember(Name = "productWidth")]
        public decimal? ProductWidth { get; set; }

        [DisplayName("Product Height")]
        [DataMember(Name = "productHeight")]
        public decimal? ProductHeight { get; set; }

        [DisplayName("Product Weight")]
        [DataMember(Name = "productWeight")]
        public decimal? ProductWeight { get; set; }

        [DisplayName("Last Supplier ID")]
        [DataMember(Name = "lastSupplierId")]
        public Guid? LastSupplierId { get; set; }

        [DisplayName("Is Sellable")]
        [DataMember(Name = "isSellable")]
        public bool IsSellable { get; set; }

        [DisplayName("Is Purchaseable")]
        [DataMember(Name = "isPurchasable")]
        public bool IsPurchaseable { get; set; }

        [DisplayName("Is Active")]
        [DataMember(Name = "isActive")]
        public bool IsActive { get; set; }

        [DisplayName("Image ID")]
        [DataMember(Name = "imageId")]
        public Guid? ImageId { get; set; }

        [DisplayName("SKU Code")]
        [DataMember(Name = "skuCode")]
        public string SKUCode { get; set; }

        [DisplayName("Last Purchase Price")]
        [DataMember(Name = "lastPurchasePrice")]
        public decimal LastPurchasePrice { get; set; }

        [DisplayName("Base Price")]
        [DataMember(Name = "basePrice")]
        public decimal BasePrice { get; set; }

        [DisplayName("Shelf Price")]
        [DataMember(Name = "shelfPrice")]
        public decimal ShelfPrice { get; set; }

        [DisplayName("Promotion ID")]
        [DataMember(Name = "promotionId")]
        public Guid PromotionId { get; set; }


        [DataMember(Name = "imageFileIds")]
        public List<Guid> ImageFileIds { get; set; }


        public List<ProductVariantAttributeValueViewModel> ProductVariantAttributeValues { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get
            {
                return ProductVariantId;
            }
            set
            {
                ProductVariantId = value;
            }
        }
    }

    [DataContract]
    public class ProductVariantListItem
    {
        [DataMember(Name = "productVariantId")]
        public Guid ProductVariantId { get; set; }

        [DataMember(Name = "attributeValueString")]
        public string AttributeValuesString { get; set; }

        [DataMember(Name = "availableQuantity")]
        public int AvailableQuantity { get; set; }

        [DataMember(Name = "skuCode")]
        public string SKUCode { get; set; }

        [DataMember(Name = "basePrice")]
        public decimal BasePrice { get; set; }

        [DataMember(Name = "shelfPrice")]
        public decimal ShelfPrice { get; set; }

    }
}
