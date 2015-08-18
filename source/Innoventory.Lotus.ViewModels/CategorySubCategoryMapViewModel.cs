using Innoventory.Lotus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    [DataContract]
    public class CategorySubCategoryMapViewModel : IIdentifiable
    {
        [DataMember(Name = "categorySubCategoryMapId")]
        public Guid CategorySubCategoryMapId { get; set; }

        [DataMember(Name = "categoryId")]
        public Guid CategoryId { get; set; }

        [DataMember(Name = "subCategoryId")]
        public Guid SubCategoryId { get; set; }

        [DataMember(Name = "category")]
        public CategoryViewModel Category { get; set; }

        [DataMember(Name = "subCategory")]
        public SubCategoryViewModel SubCategory { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return CategorySubCategoryMapId; }
            set { CategorySubCategoryMapId = value; }
        }
    }
}
