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

        [DataMember(Name="attributeId")]
        public string AttributeId
        {
            get { return AttributeName.Trim().Replace(" ", ""); }
        }

        [DataMember(Name="attributeValues")]
        public List<AttributeValueItem> AttributeValues { get; set; }

        [DataMember(Name="selectedAttributeValue")]
        public AttributeValueItem SelectedAttributeValue { get; set; }


    }

    [DataContract]
    public class AttributeValueItem 
    {
        [DataMember(Name="attributeValueListId")]
        public Guid AttributeValueListId { get; set; }


        [DataMember(Name = "attributeValue")]
        public string AttributeValue { get; set; }
    }
}
