using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.BusinessTransition
{
    public interface ISubCategoryTransition
    {
        UpdateResult<SubCategoryViewModel> UpdateSubCategory(SubCategoryViewModel subCategoryViewModel);

        FindResult<SubCategoryViewModel> GetAllSubcategories();

        SubCategoryCategories GetSubCategoryCategories(Guid subCategoryId);

        FindResult<SubCategoryViewModel> GetAllSubcategoriesByCategory(Guid id);
    }
}
