using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{


    public class AttributeValueListViewModel
    {

       [ScaffoldColumn(false)]
        public Guid AttributeValueListId { get; set; }

        public Guid CategorySubCategoryAttributeMapID { get; set; }

        [DisplayName("Attribute Value")]
        public string AttributeValue { get; set; }


        
        public CategorySubCategoryAttributeMapViewModel CategorySubCategoryAttributeMap { get; set; }

        public List<ProductVariantAttributeValueViewModel> ProductVariantAttributeValue { get; set; }
    }
}
