using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
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

    }
}
