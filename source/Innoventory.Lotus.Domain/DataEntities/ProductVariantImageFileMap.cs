﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Domain.DataEntities
{
    public class ProductVariantImageFileMap
    {
        [Key]
        [Column(Order = 1)]
        public Guid ProductVariantImageFileMapId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid ImageFileId { get; set; }


        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        [ForeignKey("ImageFileId")]
        public virtual List<ImageFile> ImageFiles{ get; set; }


    }
}
