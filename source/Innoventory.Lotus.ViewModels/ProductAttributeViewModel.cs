using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;
using System.Runtime.Serialization;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class ProductAttributeViewModel : IIdentifiable
    {
        [ScaffoldColumn(false)]
        [DataMember(Name="productAttributeId")]
        public Guid ProductAttributeId { get; set; }

        [DataMember(Name="attributeName")]
        public string AttributeName { get; set; }

        [DataMember(Name="attributeDescription")]
        public string AttributeDescription { get; set; }

        [DataMember(Name = "subCategoryNames")]
        public string SubCategoryNames { get; set; }

        [DataMember(Name = "subCategorySelections")]
        public List<SubCategorySelection> SubCategorySelections { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get
            {
                return ProductAttributeId;
            }
            set
            {
                ProductAttributeId = value;
            }
        }
    }

    

    [DataContract]
    public class SubCategorySelection
    {

        [DataMember(Name="subCategory")]
        public SubCategoryViewModel SubCategory { get; set; }

        [DataMember(Name="isSelected")]
        public bool IsSelected { get; set; }


    }
}
