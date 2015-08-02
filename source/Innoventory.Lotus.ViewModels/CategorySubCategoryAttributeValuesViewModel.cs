using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class CategorySubCategoryAttributeValuesViewModel
    {

        [DataMember(Name="categorySubCategoryMapId")]
        public Guid CategorySubCategoryMapId { get; set; }

        [DataMember(Name = "productAttributeId")]
        public Guid ProductAttributeId { get; set; }

        [DataMember(Name = "attributeName")]
        public string AttributeName { get; set; }


        public List<AttributeValues> AttributeValues { get; set; }


    }

    [DataContract]
    public class AttributeValues
    {
        [DataMember(Name="attributeValueListId")]
        public Guid AttributeValueListId { get; set; }


        [DataMember(Name = "attributeValue")]
        public string AttributeValue { get; set; }
    }
}
