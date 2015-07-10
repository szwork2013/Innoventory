using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Database.DataEntities
{
   public  class ImageFile
    {
        [Key]
        public Guid ImageFileId { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }

        [StringLength(100)]
        public string ImageType { get; set; }

        public byte[] ImageData { get; set; }

        public virtual ProductVariant  ProductVariant { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<ProductVariantImageFileMap> ProductVariantImageFileMaps { get; set; } 
    }
}
