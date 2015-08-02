using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Innoventory.Lotus.ViewModels;


namespace Innoventory.Lotus.BusinessTransition
{
    public interface IProductAttributeTransition
    {

        FindResult<ProductAttributeViewModel> GetProductAttributes();

        FindResult<ProductAttributeViewModel> Find(Func<ProductAttributeViewModel, bool> predicate);

        GetEntityResult<ProductAttributeViewModel> FindById(Guid id);

        UpdateResult<ProductAttributeViewModel> UpdateProductAttribute(ProductAttributeViewModel productAttribute);


        DeleteResult<ProductAttributeViewModel> Delete(Guid id);
    }
}
