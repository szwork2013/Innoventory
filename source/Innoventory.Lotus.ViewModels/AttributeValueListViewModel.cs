using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{

    [DataContract]
    public class AttributeValueListViewModel : IIdentifiable
    {

        [ScaffoldColumn(false)]
        [DataMember(Name = "attributeValueListId")]
        public Guid AttributeValueListId { get; set; }


        [DataMember(Name = "categoryId")]
        public Guid CategoryId { get; set; }

        [DataMember(Name = "subCategoryAttributeMapId")]
        public Guid SubCategoryAttributeMapID { get; set; }

        [DisplayName("Attribute Value")]
        [DataMember(Name = "attributeValue")]
        public string AttributeValue { get; set; }

        [DataMember(Name = "attributeName")]
        public string AttributeName { get; set; }

        [DataMember(Name = "subCategoryName")]
        public string SubCategoryName { get; set; }

        
        [ScaffoldColumn(false)]
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
