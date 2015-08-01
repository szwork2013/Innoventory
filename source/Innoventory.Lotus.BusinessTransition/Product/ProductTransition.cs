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
using System.Runtime.Caching;

namespace Innoventory.Lotus.BusinessTransition
{

    [Export(typeof(IProductTransition))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ProductTransition : IProductTransition
    {

        private const string CONST_CACHE_PRODUCT = "PRODUCT_CACHE";

        private const string CONST_CACHE_PRODUCT_VARIANT = "PRODUCT_VARIANT_CACHE";

        private MemoryCache productCache;

        //private MemoryCache productVariantCache;

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
        private IProductAttributeRepository productAttributeRepository;

        [Import]
        private ISubCategoryAttributeMapRepository categorySubCategoryAttributeMapRepository;

        [Import]
        private IAttributeValueListRepository attributeValueListRepository;

        [Import]
        private IProductVariantAttributeValueRepository productVariantAttributeValueRepository;


        [Import]
        private IProductVariantImageFileMapRepository productVariantImageFileMapRepository;

        public GetEntityResult<ProductViewModel> GetProduct(Guid productId)
        {
            GetEntityResult<ProductViewModel> entityResult = new GetEntityResult<ProductViewModel>();

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {
                GetEntityResult<ProductViewModel> productResult = productRepository.FindById(dbContext, productId);
                if (!productResult.Success)
                {
                    return productResult;

                }

                ProductViewModel product = productResult.Entity;

                FindResult<ProductVariantViewModel> findProductVriantResult = productVariantRepository.FindBy(dbContext, x => x.ProductId == productId);

                if(!findProductVriantResult.Success)
                {
                    entityResult.Success = false;
                    entityResult.ErrorMessage = findProductVriantResult.ErrorMessage;
                    return entityResult;
                }


                List<ProductVariantViewModel> productVariants = findProductVriantResult.Entities;

                product.ProductVariants = productVariants;

                long categoryAttributeCount = 0;

                FindResult<SubCategoryAttributeMapViewModel> catSubCatAttribMapResult = categorySubCategoryAttributeMapRepository.FindBy(dbContext, x => x.SubCategoryId == product.CategorySubCategoryMapId);

                if(catSubCatAttribMapResult.Success && catSubCatAttribMapResult.Count> 0)
                {

                    categoryAttributeCount = catSubCatAttribMapResult.Count;

                }

                foreach (ProductVariantViewModel pvm in productVariants)
                {
                    GetEntityResult<VolumeMeasureViewModel> purchaseVMResult = volumeMeasureRepository.FindById(pvm.PurchaseVolueMeasureId);

                    if(purchaseVMResult.Success)
                    {
                        pvm.PurchaseVMShortName = purchaseVMResult.Entity.ShortName;
                    }

                    GetEntityResult<VolumeMeasureViewModel> salesVMResult = volumeMeasureRepository.FindById(pvm.SalesVolumeMeasureId);

                    if (salesVMResult.Success)
                    {
                        pvm.SalesVMShortName = salesVMResult.Entity.ShortName;
                    }

                    if(categoryAttributeCount > 0)
                    {
                        List<SubCategoryAttributeMapViewModel> catSubCatAttribList = catSubCatAttribMapResult.Entities;
                        
                    }


                }
                
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
