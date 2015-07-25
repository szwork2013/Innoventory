using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{
    public class ProductVariantImageFileMapViewModel:IIdentifiable
    {
        public Guid ProductVariantId { get; set; }

        public Guid ImageFileId { get; set; }


        public ProductVariantViewModel ProductVariant { get; set; }

        public List<ImageFileViewModel> ImageFiles{ get; set; }


        [ScaffoldColumn(false)]

        public Guid EntityId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
