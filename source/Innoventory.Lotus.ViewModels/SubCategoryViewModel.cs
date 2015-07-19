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
    public class SubCategoryViewModel : IIdentifiable
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

        public Guid EntityId
        {
            get { return SubCategoryId; }
            set { SubCategoryId = value; }
        }
    }

    public class SubCategoryCategories
    {
        public SubCategoryViewModel SubCategory { get; set; }

        public List<CategorySelectionViewModel> CategorySelections { get; set; }
    }
}
