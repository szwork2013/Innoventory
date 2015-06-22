using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class ProductVariant
    {
        [Key]
        public Guid ProductVariantId { get; set; }

        public Guid ProductId { get; set; }

        [StringLength(500)]
        public string BarCode { get; set; }

        public decimal? MasterPackQty { get; set; }
        
        public decimal? InnerPackQty { get; set; }
        
        public decimal? CaseLength { get; set; }
        
        public decimal? CaseWidth { get; set; }
        
        public decimal? CaseHeight { get; set; }
        
        public decimal? CaseWeight { get; set; }
        
        public decimal? ProductLength { get; set; }
        
        public decimal? ProductWidth { get; set; }
        
        public decimal? ProductHeight { get; set; }
        
        public decimal? ProductWeight { get; set; }
        
        public int? LastVendorId { get; set; }
        
        public bool IsSellable { get; set; }
        
        public bool IsPurchaseable { get; set; }
        
        public bool IsActive { get; set; }
        
        public Guid? ImageId { get; set; }
        
        public string SKUCode { get; set; }
        
        public decimal LastPurchasePrice { get; set; }
        
        public decimal BasePrice { get; set; }
        
        public decimal ShelfPrice { get; set; }
        
        public Guid PromotionId { get; set; }

        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
