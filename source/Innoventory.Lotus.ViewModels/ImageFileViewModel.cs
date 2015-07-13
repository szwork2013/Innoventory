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
   public  class ImageFileViewModel:IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public Guid ImageFileId { get; set; }

        [DisplayName("Image URL")]
        [DataMember]
        public string ImageUrl { get; set; }

        [DisplayName("Image Type")]
        [DataMember]
        public string ImageType { get; set; }

        [DisplayName("Image Data")]
        [DataMember]
        public byte[] ImageData { get; set; }

        public ProductVariantViewModel  ProductVariant { get; set; }

        public ProductViewModel Product { get; set; }

        public List<ProductVariantImageFileMapViewModel> ProductVariantImageFileMaps { get; set; }

        public Guid EntityId
        {
            get
            {
                return ImageFileId;
            }
            set
            {
                ImageFileId = value;
            }
        }
    }
}
