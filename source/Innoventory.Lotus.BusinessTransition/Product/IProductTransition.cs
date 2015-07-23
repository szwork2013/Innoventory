using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.BusinessTransition
{
    public interface IProductTransition
    {

        GetEntityResult<ProductViewModel> GetProduct(Guid productId);

        FindResult<ProductViewModel> GetAllProducts(ProductFilterOption filterOption, SortOption sortOption);

        UpdateResult<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);

        bool UpdateProductToInactive(Guid productId);

        bool ActivateProduct(Guid productId);

        PreCacheResult<ProductViewModel> PreCache();

        
    }


   
}
