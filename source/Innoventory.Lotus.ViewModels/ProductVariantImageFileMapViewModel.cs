using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Innoventory.Lotus.ViewModels
{
    public class ProductVariantImageFileMapViewModel
    {
        public Guid ProductVariantId { get; set; }

        public Guid ImageFileId { get; set; }


        public ProductVariantViewModel ProductVariant { get; set; }

        public List<ImageFileViewModel> ImageFiles{ get; set; }


    }
}
