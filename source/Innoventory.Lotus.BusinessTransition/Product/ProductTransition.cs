using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Innoventory.Lotus.Database;
using Innoventory.Lotus.ViewModels;
using Innoventory.Lotus.Business;
using Innoventory.Lotus.Database.DataEntities;
using System.ComponentModel.Composition;
using Innoventory.Lotus.Business.Abstract;

namespace Innoventory.Lotus.BusinessTransition
{

    [Export(typeof(IProductTransition))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ProductTransition : IProductTransition
    {
        [Import]
        private IProductRepository productRepository;

        [Import]
        private IProductVariantRepository productVariantRepository;

        [Import]
        private ICategorySubCategoryMapRepository categorySubCategoryMapRepository;

        [Import]
        private ICategoryRepository categoryRepository;

        [Import]
        private ISubCategoryRepository subCategoryRepository;

        [Import]
        private IVolumeMeasureRepository volumeMeasureRepository;

        [Import]
        private IImageFileRepository imageFileRepository;

        [Import]
        private IProductAttibuteRepository productAttributeRepository;

        [Import]
        private ICategorySubCategoryAttributeMapRepository categorySubCategoryAttributeMapRepository  ;

        [Import]
        private IAttributeValueListRepository  attributeValueListRepository;

        [Import]
        private IProductVariantAttributeValueRepository productVariantAttributeValueRepository;


        [Import]
        private IProductVariantImageFileMapRepository productVariantImageFileMapRepository;
        
        public GetEntityResult<ViewModels.ProductViewModel> GetProduct(Guid productId)
        {
            GetEntityResult<ProductViewModel> entityResult = new GetEntityResult<ProductViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

            }

            return entityResult;
        }

        public FindResult<ViewModels.ProductViewModel> GetAllProducts(ViewModels.ProductFilterOption filterOption, ViewModels.SortOption sortOption)
        {
            throw new NotImplementedException();
        }

        public UpdateResult<ViewModels.ProductViewModel> UpdateProduct(ViewModels.ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductToInactive(Guid productId)
        {
            throw new NotImplementedException();
        }

        public bool ActivateProduct(Guid productId)
        {
            throw new NotImplementedException();
        }



        public PreCacheResult<ProductViewModel> PreCache()
        {
            throw new NotImplementedException();
        }
    }
}
