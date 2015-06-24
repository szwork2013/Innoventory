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
    public class ProductVariantViewModel
    {


        [Key]
        [DataMember(Name = "productVariantId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public Guid ProductVariantId { get; set; }

        [ScaffoldColumn(false)]
        [Browsable(false)]
        [DataMember(Name = "productId")]
        public Guid ProductId { get; set; }

        [DataMember(Name = "barCode")]
        public string BarCode { get; set; }

        [DataMember(Name = "masterPackQty")]
        public decimal? MasterPackQty { get; set; }

        [DataMember(Name = "innerPackQty")]
        public decimal? InnerPackQty { get; set; }

        [DataMember(Name = "caseLength")]
        public decimal? CaseLength { get; set; }

        [DataMember(Name = "caseWidth")]
        public decimal? CaseWidth { get; set; }

        [DataMember(Name = "caseHeight")]
        public decimal? CaseHeight { get; set; }

        [DataMember(Name = "caseWeight")]
        public decimal? CaseWeight { get; set; }

        [DataMember(Name = "productLength")]
        public decimal? ProductLength { get; set; }

        [DataMember(Name = "productWidth")]
        public decimal? ProductWidth { get; set; }

        [DataMember(Name = "productHeight")]
        public decimal? ProductHeight { get; set; }

        [DataMember(Name = "productWeight")]
        public decimal? ProductWeight { get; set; }

        [DataMember(Name = "lastVendorId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public int? LastVendorId { get; set; }

        [DataMember(Name = "isSellable")]
        public bool IsSellable { get; set; }

        [DataMember(Name = "isPurchaseable")]
        public bool IsPurchaseable { get; set; }

        [DataMember(Name = "isActive")]
        public bool IsActive { get; set; }

        [DataMember(Name = "imageId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public Guid? ImageId { get; set; }

        [DataMember(Name = "skuCode")]
        public string SKUCode { get; set; }

        [DataMember(Name = "lastPurchasePrice")]
        public decimal LastPurchasePrice { get; set; }

        [DataMember(Name = "basePrice")]
        public decimal BasePrice { get; set; }

        [DataMember(Name = "shelfPrice")]
        public decimal ShelfPrice { get; set; }

        [DataMember(Name = "promotionId")]
        [ScaffoldColumn(false)]
        [Browsable(false)]
        public Guid PromotionId { get; set; }


    }
}
