using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{


    public class AttributeValueListViewModel:IIdentifiable
    {

       [ScaffoldColumn(false)]
        public Guid AttributeValueListId { get; set; }

        public Guid CategorySubCategoryAttributeMapID { get; set; }

        [DisplayName("Attribute Value")]
        public string AttributeValue { get; set; }


        
        public CategorySubCategoryAttributeMapViewModel CategorySubCategoryAttributeMap { get; set; }

        public List<ProductVariantAttributeValueViewModel> ProductVariantAttributeValue { get; set; }



        public Guid EntityId
        {
            get
            {
                return AttributeValueListId;
            }
            set
            {
                AttributeValueListId = value;
            }
        }
    }
}
