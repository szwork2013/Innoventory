using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
   public  class ImageFileViewModel
    {
        public Guid ImageFileId { get; set; }

        public string ImageUrl { get; set; }

        public string ImageType { get; set; }

        public byte[] ImageData { get; set; }

        public ProductVariantViewModel  ProductVariant { get; set; }

        public ProductViewModel Product { get; set; }

        public List<ProductVariantImageFileMapViewModel> ProductVariantImageFileMaps { get; set; } 
    }
}
