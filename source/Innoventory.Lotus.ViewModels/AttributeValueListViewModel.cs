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

        public Guid SubCategoryAttributeMapID { get; set; }

        [DisplayName("Attribute Value")]
        public string AttributeValue { get; set; }


        
        public SubCategoryAttributeMapViewModel SubCategoryAttributeMap { get; set; }

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
