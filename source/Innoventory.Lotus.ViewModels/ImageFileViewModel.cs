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
    public class ImageFileViewModel : IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember(Name = "imageFileId")]
        public Guid ImageFileId { get; set; }

        [DisplayName("Image URL")]
        [DataMember(Name = "imageUrl")]
        public string ImageUrl { get; set; }

        [DisplayName("Image Type")]
        [DataMember(Name = "imageType")]
        public string ImageType { get; set; }

        [DisplayName("Image Data")]
        [DataMember(Name = "imageData")]
        public byte[] ImageData { get; set; }

        [ScaffoldColumn(false)]
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
