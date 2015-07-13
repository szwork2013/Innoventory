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
    public class ProductVariantViewModel:IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid ProductVariantId { get; set; }

        [DisplayName("Product ID")]
        [DataMember]
        public Guid ProductId { get; set; }

        [DisplayName("Bar Code")]
        [DataMember]
        public string BarCode { get; set; }

        [DisplayName("Market Pack Quantity")]
        [DataMember]
        public decimal? MasterPackQty { get; set; }

        [DisplayName("Inner Pack Quantity")]
        [DataMember]
        public decimal? InnerPackQty { get; set; }

        [DisplayName("Case Length")]
        [DataMember]
        public decimal? CaseLength { get; set; }

        [DisplayName("Case Width")]
        [DataMember]
        public decimal? CaseWidth { get; set; }

        [DisplayName("Case Height")]
        [DataMember]
        public decimal? CaseHeight { get; set; }

        [DisplayName("Case Weight")]
        [DataMember]
        public decimal? CaseWeight { get; set; }

        [DisplayName("Product Length")]
        [DataMember]
        public decimal? ProductLength { get; set; }

        [DisplayName("Product Width")]
        [DataMember]
        public decimal? ProductWidth { get; set; }

        [DisplayName("Product Height")]
        [DataMember]
        public decimal? ProductHeight { get; set; }

        [DisplayName("Product Weight")]
        [DataMember]
        public decimal? ProductWeight { get; set; }

        [DisplayName("Last Vendor ID")]
        [DataMember]
        public int? LastVendorId { get; set; }

        [DisplayName("Is Sellable")]
        [DataMember]
        public bool IsSellable { get; set; }

        [DisplayName("Is Purchaseable")]
        [DataMember]
        public bool IsPurchaseable { get; set; }

        [DisplayName("Is Active")]
        [DataMember]
        public bool IsActive { get; set; }

        [DisplayName("Image ID")]
        [DataMember]
        public Guid? ImageId { get; set; }

        [DisplayName("SKU Code")]
        [DataMember]
        public string SKUCode { get; set; }

        [DisplayName("Last Purchase Price")]
        [DataMember]
        public decimal LastPurchasePrice { get; set; }

        [DisplayName("Base Price")]
        [DataMember]
        public decimal BasePrice { get; set; }

        [DisplayName("Shelf Price")]
        [DataMember]
        public decimal ShelfPrice { get; set; }

        [DisplayName("Promotion ID")]
        [DataMember]
        public Guid PromotionId { get; set; }



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
}
