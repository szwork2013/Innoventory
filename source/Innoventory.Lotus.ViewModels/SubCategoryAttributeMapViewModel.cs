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
    public class SubCategoryAttributeMapViewModel : IIdentifiable
    {

        [ScaffoldColumn(false)]
        [DataMember(Name = "subCategoryAttributeMapId")]
        public Guid SubCategoryAttributeMapId { get; set; }

        [DataMember(Name = "subCategoryId")]
        public Guid SubCategoryId { get; set; }

        [DataMember(Name = "productAttributeId")]
        public Guid ProductAttributeId { get; set; }

        [DataMember(Name = "subCategorVM")]
        public SubCategoryViewModel SubCategory { get; set; }

        //[DataMember(Name = "productAttributeVM")]
        //public ProductAttributeViewModel ProductAttribute { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return SubCategoryAttributeMapId; }
            set { SubCategoryAttributeMapId = value; }
        }
    }


}
