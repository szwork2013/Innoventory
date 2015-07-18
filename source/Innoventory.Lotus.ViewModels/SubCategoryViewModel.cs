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

    public class SubCategoryViewModel : IIdentifiable
    {

        [Key]
        [ScaffoldColumn(false)]
        public Guid SubCategoryId { get; set; }


        [Required]
        [StringLength(50)]
        public string SubCategoryName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string SelectedCategories { get; set; }

        //Selected category Ids
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
