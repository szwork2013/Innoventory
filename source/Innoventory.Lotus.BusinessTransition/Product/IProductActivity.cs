using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.BusinessActivity
{
    public interface IProductActivity
    {

        GetEntityResult<ProductViewModel> GetProduct(Guid productId);

        FindResult<ProductListItem> GetAllProductListItems(ProductFilterOption filterOption);

        UpdateResult<ProductViewModel> SaveProduct(ProductViewModel productViewModel);

        bool UpdateProductToInactive(Guid productId);

        bool ActivateProduct(Guid productId);

        PreCacheResult<ProductViewModel> PreCache();

        
    }


   
}
