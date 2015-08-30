using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.BusinessActivity
{
    public interface ISubCategoryBusinessAcitvity
    {
        UpdateResult<SubCategoryViewModel> UpdateSubCategory(SubCategoryViewModel subCategoryViewModel);

        FindResult<SubCategoryViewModel> GetAllSubcategories();

        SubCategoryCategories GetSubCategoryCategories(Guid subCategoryId);

        FindResult<SubCategoryViewModel> GetAllSubcategoriesByCategory(Guid id);

        GetEntityResult<CategorySubCategoryMapViewModel> GetCategorySubCategoryMap(Guid categoryId, Guid subCategoryId);
    }
}
