using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.ViewModels
{
    public class CategorySubCategoryMapViewModel
    {

        public Guid CategorySubCategoryMapId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SubCategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}
