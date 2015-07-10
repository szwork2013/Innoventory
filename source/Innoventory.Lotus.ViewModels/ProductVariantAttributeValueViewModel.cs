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
    public class ProductVariantAttributeValueViewModel:IIdentifiable
    {


        public Guid ProductVariantId { get; set; }

        public Guid AttributeValueListId { get; set; }

        public AttributeValueListViewModel AttributeValueList { get; set; }


        public ProductVariantViewModel ProductVariant { get; set; }



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
