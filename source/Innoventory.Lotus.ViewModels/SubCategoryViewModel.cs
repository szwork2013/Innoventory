using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Core.Contracts;

namespace Innoventory.Lotus.ViewModels
{

    [DataContract]
    public class SubCategoryViewModel : IIdentifiable, IDisplayName
    {

        [Key]
        [ScaffoldColumn(false)]
        [DataMember(Name = "subCategoryId")]
        public Guid SubCategoryId { get; set; }


        [Required]
        [StringLength(50)]
        [DataMember(Name = "subCategoryName")]
        public string SubCategoryName { get; set; }

        [Required]
        [StringLength(500)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "selectedCategoryNames")]
        public string SelectedCategoryNames { get; set; }


        //Selected category Ids
        [DataMember(Name = "categoryIds")]
        public List<Guid> CategoryIds { get; set; }

        [ScaffoldColumn(false)]
        public Guid EntityId
        {
            get { return SubCategoryId; }
            set { SubCategoryId = value; }
        }

        [ScaffoldColumn(false)]
        public string DisplayName
        {
            get { return SubCategoryName; }
        }
    }

    [DataContract]
    public class SubCategoryCategories
    {
        [DataMember(Name = "subCategory")]
        public SubCategoryViewModel SubCategory { get; set; }

        [DataMember(Name = "categorySelections")]
        public List<CategorySelectionViewModel> CategorySelections { get; set; }
    }

    [DataContract]
    public class CategorySelectionViewModel
    {
        [DataMember(Name = "category")]
        public CategoryViewModel CategoryVM { get; set; }

        [DataMember(Name = "isSelected")]
        public bool IsSelected { get; set; }

    }


}
